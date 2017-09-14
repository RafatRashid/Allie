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
    public class LedgerController : BaseController
    {
        // GET: Ledger
        public ActionResult Index()
        {
            return View(ServiceFactory.GetLedgerServices().GetAll((int)Session["CompanyId"]));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection Form)
        {
            Ledger led = new Ledger();
            led.LedgerPeriod = new DateTime(Convert.ToInt32(Form["Year"]), Convert.ToInt32(Form["Month"]) + 1, 1);
            led.LedgerDescription = Form["Description"];
            led.CompanyId = Convert.ToInt32(Session["CompanyId"]);

            Journal j = ServiceFactory.GetJournalServices().Get(led.CompanyId, led.LedgerPeriod);
            List<Account> accList = new List<Account>();
            List<int> idList = (List<int>)ServiceFactory.GetTransactionDetailServices().GetDistinctAccount(j.Id);
            IAccountServices accService = ServiceFactory.GetAccountServices();

            foreach (int i in idList)
            {
                Account acc = accService.Get(i);
                accList.Add(acc);
            }

            Session["Ledger"] = led;
            Session["Journal"] = j;
            Session["AccountList"] = accList;

            if (j.LedgerId != 0)
            {
                return RedirectToAction("GetStoredLedger", new { id = j.LedgerId });
            }
            return RedirectToAction("GenerateLedger");
        }

        [HttpGet]
        public ActionResult GenerateLedger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateLedger(FormCollection Form)
        {
            Ledger led = (Ledger)Session["Ledger"];
            Journal jour = (Journal)Session["Journal"];

            ServiceFactory.GetLedgerServices().Insert(led);
            jour.LedgerId = led.Id;
            ServiceFactory.GetJournalServices().Update(jour);

            Session["Ledger"] = null;
            Session["Journal"] = null;
            Session["AccountList"] = null;
            return RedirectToAction("Index", "Company");
        }

        [HttpGet]
        public ActionResult GetStoredLedger(int id)
        {
            return View(ServiceFactory.GetLedgerServices().Get(id));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Ledger led = ServiceFactory.GetLedgerServices().Get(id);
            Journal journal = ServiceFactory.GetJournalServices().GetByLedger(led.Id);
            List<int> accId = (List<int>)ServiceFactory.GetTransactionDetailServices().GetDistinctAccount(journal.Id);
            List<Account> accList = new List<Account>();
            IAccountServices accService = ServiceFactory.GetAccountServices();

            foreach (int i in accId)
            {
                Account ac = accService.Get(i);
                accList.Add(ac);
            }
            Session["Ledger"] = led;
            Session["Journal"] = journal;
            Session["AccountList"] = accList;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetLedgerServices().Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Ledger led)
        {
            if (ValidateLedger.IsValid(led))
            {
                ServiceFactory.GetLedgerServices().Update(led);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = ValidateLedger.Message;
                return View(ServiceFactory.GetLedgerServices().Get(led.Id));
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(ServiceFactory.GetLedgerServices().Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(Ledger led)
        {
            IJournalServices service = ServiceFactory.GetJournalServices();
            Journal journal = service.GetByLedger(led.Id);
            journal.LedgerId = 0;
            service.Update(journal);

            ServiceFactory.GetLedgerServices().Delete(led.Id);
            return RedirectToAction("Index");
        }
    }
}