using Allie.Models;
using Allie.ValidationClasses;
using AllieEntity;
using AllieService;
using AllieService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class TransactionController : BaseController
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View(ServiceFactory.GetTransactionServices().GetAll((int)Session["CompanyId"]));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateInternal()
        {
            List<Account> accList = (List<Account>) ServiceFactory.GetAccountServices().GetAll((int)Session["CompanyId"]);
            List<SelectListItem> itemList = new List<SelectListItem>();

            foreach(Account acc in accList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = acc.AccountDescription;
                item.Value = acc.Id.ToString();
                
                itemList.Add(item);
            }
            SelectListItem temp = new SelectListItem()
            {
                Text = "none",
                Value = "none",
            };
            temp.Selected = true;
            itemList.Add(temp);

            ViewBag.SelectList = itemList;
            ViewBag.AccountList = accList;
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternal(FormCollection form)
        {
            Transaction transaction = new Transaction();
            TransactionDetail sourceDetail = new TransactionDetail();
            TransactionDetail destDetail = new TransactionDetail();

            transaction.TransactionAmount = Convert.ToDouble(form["SourceAcc_Amount"]);
            transaction.TransactionDate = Convert.ToDateTime(form["TransactionDate"]).Date;
            transaction.TransactionDescription = form["Description"];
            transaction.CompanyId = (int)Session["CompanyId"];

            ServiceFactory.GetTransactionServices().Insert(transaction);

            sourceDetail.AccountId = Convert.ToInt32(form["SourceAcc_Account"]);
            sourceDetail.Amount = transaction.TransactionAmount;
            sourceDetail.TransactionId = transaction.Id;
            sourceDetail.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(form["SourceAcc_TransactionType"]).Id;
            
            destDetail.AccountId = Convert.ToInt32(form["DestAcc_Account"]);
            destDetail.Amount = transaction.TransactionAmount;
            destDetail.TransactionId = transaction.Id;
            destDetail.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(form["DestAcc_TransactionType"]).Id;

            ServiceFactory.GetTransactionDetailServices().Insert(sourceDetail);
            ServiceFactory.GetTransactionDetailServices().Insert(destDetail);

            ServiceFactory.GetAccountServices().CashOut(sourceDetail.AccountId, sourceDetail.Amount);

            int id = ServiceFactory.GetAccountServices().Get(destDetail.AccountId).AccountType;
            string type = ServiceFactory.GetAccountTypeServices().Get(id).Type;

            if(type == "Liability")
                ServiceFactory.GetAccountServices().CashOut(destDetail.AccountId, destDetail.Amount);
            else 
                ServiceFactory.GetAccountServices().CashIn(destDetail.AccountId, destDetail.Amount);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult CreateExternal()
        {
            List<Account> accList = (List<Account>)ServiceFactory.GetAccountServices().GetAll((int)Session["CompanyId"]);
            List<SelectListItem> itemList = new List<SelectListItem>();

            foreach (Account acc in accList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = acc.AccountDescription;
                item.Value = acc.Id.ToString();

                itemList.Add(item);
            }
            SelectListItem temp = new SelectListItem()
            {
                Text = "none",
                Value = "none",
            };
            temp.Selected = true;
            itemList.Add(temp);

            ViewBag.SelectList = itemList;
            ViewBag.AccountList = accList;
            return View();
        }
        [HttpPost]
        public ActionResult CreateExternal(FormCollection Form)
        {
            Transaction transaction = new Transaction();
            TransactionDetail account1 = new TransactionDetail();
            TransactionDetail account2 = new TransactionDetail();

            transaction.TransactionAmount = Convert.ToDouble(Form["Amount"]);
            transaction.TransactionDate = Convert.ToDateTime(Form["TransactionDate"]).Date;
            transaction.TransactionDescription = Form["Description"];
            transaction.CompanyId = (int)Session["CompanyId"];

            ServiceFactory.GetTransactionServices().Insert(transaction);

            if(Form["Account_1"] != "none")
            {
                account1.AccountId = Convert.ToInt32(Form["Account_1"]);
                account1.Amount = transaction.TransactionAmount;
                account1.TransactionId = transaction.Id;
                account1.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(Form["Account_1_TransactionType"]).Id;
                ServiceFactory.GetTransactionDetailServices().Insert(account1);
                ServiceFactory.GetAccountServices().CashIn(account1.AccountId, account1.Amount);
            }
            if(Form["Account_2"] != "none")
            {
                account2.AccountId = Convert.ToInt32(Form["Account_2"]);
                account2.Amount = transaction.TransactionAmount;
                account2.TransactionId = transaction.Id;
                account2.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(Form["Account_2_TransactionType"]).Id;
                ServiceFactory.GetTransactionDetailServices().Insert(account2);
                ServiceFactory.GetAccountServices().CashIn(account2.AccountId, account2.Amount);
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Transaction t = ServiceFactory.GetTransactionServices().Get(id);
            ViewBag.Transaction = t;
            return View(ServiceFactory.GetTransactionDetailServices().GetAll(t.Id));
        }

        [HttpPost]
        public string GetTransactionType(int accId, bool source)
        {
            return ServiceFactory.GetTransactionTypeServices().Get(accId, source).Type;
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Transaction t = ServiceFactory.GetTransactionServices().Get(id);
            ViewBag.Transaction = t;
            return View(ServiceFactory.GetTransactionDetailServices().GetAll(t.Id));
        }

        [HttpGet]
        public ActionResult DeleteWithRollBack(int id)
        {
            Transaction transaction = ServiceFactory.GetTransactionServices().Get(id);
            if (transaction.JournalId != 0)
                ServiceFactory.GetJournalServices().Delete(transaction.JournalId);

            IAccountServices accService = ServiceFactory.GetAccountServices();
            ITransactionTypeServices tTypeService = ServiceFactory.GetTransactionTypeServices();
            ITransactionDetailServices detailService = ServiceFactory.GetTransactionDetailServices();

            List<TransactionDetail> detail = (List<TransactionDetail>)detailService.GetAll(transaction.Id);
            List<Account> accList = new List<Account>();
            foreach (TransactionDetail d in detail)
            {
                Account acc = accService.Get(d.AccountId);
                TransactionType type = tTypeService.Get(d.TransactionType);
                string action = accService.GetRollBackAction(acc.Id, type.Type);

                if (action == "Increase")
                    acc.Amount += d.Amount;
                else
                    acc.Amount -= d.Amount;
                accService.Update(acc);
                accList.Add(acc);
                detailService.Delete(d.Id);
            }
            ServiceFactory.GetTransactionServices().Delete(transaction.Id);
            ViewBag.AccountList = accList;
            return View();
        }

        [HttpGet]
        public ActionResult DeleteWithoutRollBack(int id)
        {
            ITransactionServices transactionService = ServiceFactory.GetTransactionServices();
            ITransactionDetailServices detailService = ServiceFactory.GetTransactionDetailServices();

            Transaction t = transactionService.Get(id);
            if (t.JournalId != 0)
                ServiceFactory.GetJournalServices().Delete(t.JournalId);

            List<TransactionDetail> detail = (List<TransactionDetail>)detailService.GetAll(t.Id);
            List<int> accId = new List<int>();

            foreach (TransactionDetail d in detail)
            {
                accId.Add(d.AccountId);
                detailService.Delete(d.Id);
            }
            transactionService.Delete(t.Id);
            return View(accId);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetTransactionServices().Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ValidateTransaction.IsValid(transaction))
            {
                ServiceFactory.GetTransactionServices().Update(transaction);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = ValidateTransaction.Message;
                return View();
            }
        }
    }
}