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
        public ActionResult Create(FormCollection form)
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
            ServiceFactory.GetAccountServices().CashIn(destDetail.AccountId, destDetail.Amount);

            return RedirectToAction("Index", "Company");
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
        public ActionResult AddTransaction(int id)
        {
            Transaction t = ServiceFactory.GetTransactionServices().Get(id);
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
            ViewBag.Transaction = t;
            return View();
        }
        [HttpPost]
        public ActionResult AddTransaction(FormCollection form)
        {
            Transaction transaction = ServiceFactory.GetTransactionServices().Get(Convert.ToInt32(form["TransactionId"]));
            double amount = Convert.ToDouble(form["SourceAcc_Amount"]);
            transaction.TransactionAmount += amount;

            ServiceFactory.GetTransactionServices().Update(transaction);

            TransactionDetail sourceDetail = new TransactionDetail();
            TransactionDetail destDetail = new TransactionDetail();

            sourceDetail.AccountId = Convert.ToInt32(form["SourceAcc_Account"]);
            sourceDetail.Amount = amount;
            sourceDetail.TransactionId = transaction.Id;
            sourceDetail.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(form["SourceAcc_TransactionType"]).Id;

            destDetail.AccountId = Convert.ToInt32(form["DestAcc_Account"]);
            destDetail.Amount = amount;
            destDetail.TransactionId = transaction.Id;
            destDetail.TransactionType = ServiceFactory.GetTransactionTypeServices().Get(form["DestAcc_TransactionType"]).Id;

            ServiceFactory.GetTransactionDetailServices().Insert(sourceDetail);
            ServiceFactory.GetTransactionDetailServices().Insert(destDetail);

            ServiceFactory.GetAccountServices().CashOut(sourceDetail.AccountId, sourceDetail.Amount);
            ServiceFactory.GetAccountServices().CashIn(destDetail.AccountId, destDetail.Amount);
            
            return RedirectToAction("Details", new { id = transaction.Id});
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
            List<TransactionDetail> detail = (List<TransactionDetail>)detailService.GetAll(t.Id);

            foreach (TransactionDetail d in detail)
                detailService.Delete(d.Id);

            transactionService.Delete(t.Id);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetTransactionServices().Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            Transaction previous = ServiceFactory.GetTransactionServices().Get(transaction.Id);
            transaction.CompanyId = previous.CompanyId;
            transaction.JournalId = previous.JournalId;
            transaction.TransactionAmount = previous.TransactionAmount;

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