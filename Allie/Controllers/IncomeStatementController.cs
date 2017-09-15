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
    public class IncomeStatementController : BaseController
    {
        // GET: IncomeStatement
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
            IncomeStatement statement = new IncomeStatement();
            statement.Start = new DateTime(Convert.ToInt32(Form["StartYear"]), Convert.ToInt32(Form["StartMonth"]), 1);
            statement.End = new DateTime(Convert.ToInt32(Form["EndYear"]), Convert.ToInt32(Form["EndMonth"]), 30);
            statement.CompanyId = (int)Session["CompanyId"];
            
            Session["Statement"] = statement;
            return RedirectToAction("GenerateIncomeStatement");
        }

        [HttpGet]
        public ActionResult GenerateIncomeStatement()
        {
            IncomeStatement statement = (IncomeStatement)Session["Statement"];
            List<Transaction> transactionList = (List<Transaction>)ServiceFactory.GetTransactionServices().GetAllByPeriodInterval
                                                            ((int)Session["CompanyId"], statement.Start, statement.End);
            
            Session["transactionList"] = transactionList;
            return View();
        }
        [HttpPost]
        public ActionResult GenerateIncomeStatement(FormCollection Form)
        {
            IncomeStatement statement = (IncomeStatement)Session["Statement"];
            statement.Total = Convert.ToDouble(Form["total"]);
            statement.Description = Form["Description"];

            ServiceFactory.GetIncomeStatementServices().Insert(statement);

            Session["Statement"] = null;
            Session["transactionList"] = null;
            return RedirectToAction("Index");
        }
    }
}