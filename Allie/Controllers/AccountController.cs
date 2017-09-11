using Allie.ValidationClasses;
using AllieEntity;
using AllieService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View(ServiceFactory.GetAccountServices().GetAll((int)Session["CompanyId"]));
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account acc)
        {
            if (ValidateAccount.IsValid(acc))
            {
                acc.CompanyId = (int)Session["CompanyId"];
                ServiceFactory.GetAccountServices().Insert(acc);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = ValidateAccount.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetAccountServices().Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Account acc)
        {
            if (ValidateAccount.IsValid(acc))
            {
                acc.CompanyId = (int)Session["CompanyId"];
                ServiceFactory.GetAccountServices().Update(acc);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = ValidateAccount.Message;
                Account a = ServiceFactory.GetAccountServices().Get(acc.Id);
                return View(a);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(ServiceFactory.GetAccountServices().Get(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            ServiceFactory.GetAccountServices().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetAccountServices().Get(id));
        }

        [HttpPost]
        public double GetAccountBalance(int accId)
        {
            return ServiceFactory.GetAccountServices().Get(accId).Amount;
        }
        
    }
}