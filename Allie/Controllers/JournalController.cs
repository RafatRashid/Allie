using AllieEntity;
using AllieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class JournalController : Controller
    {
        // GET: Journal
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
            Journal journal = new Journal();
            journal.JournalDescription= Form["Description"];
            journal.JournalPeriod = new DateTime(Convert.ToInt32(Form["Year"]), Convert.ToInt32(Form["Month"])+1, 1);

            Session["Journal"] = journal;
            return RedirectToAction("GenerateJournal");
        }

        [HttpGet]
        public ActionResult GenerateJournal()
        {
            Journal journal = (Journal)Session["Journal"];
            
            DateTime journalPeriod = journal.JournalPeriod;
            List<Transaction> transactionList = (List<Transaction>)ServiceFactory.GetTransactionServices()
                                                            .GetAll((int)Session["CompanyId"], journalPeriod);
            
            ViewBag.TransactionList = transactionList;
            return View();
        }
    }
}