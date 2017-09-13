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
            return View();
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
            if(j.LedgerId != 0)
            {
                //get stored ledger
            }

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

            return RedirectToAction("GenerateLedger");
        }

        [HttpGet]
        public ActionResult GenerateLedger(FormCollection Form)
        {
            return View();
        }
    }
}