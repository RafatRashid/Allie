using Allie.ValidationClasses;
using AllieEntity;
using AllieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserProfile()
        {
            int id = (int)Session["UserId"];
            return View(ServiceFactory.GetUserServices().Get(id));
        }

        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            return View(ServiceFactory.GetUserServices().Get(id));
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            if (ValidateUser.IsValid(user))
            {
                ServiceFactory.GetUserServices().Update(user);
                return RedirectToAction("UserProfile");
            }
            else
            {
                ViewBag.Error = null;
                ViewBag.Error = ValidateUser.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangePassword(int id)
        {
            return View(ServiceFactory.GetUserServices().Get(id));
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection Form)
        {
            User user = ServiceFactory.GetUserServices().Get((int)Session["UserId"]);
            if(user.Password == Form["OldPassword"])
            {
                user.Password = Form["NewPassword"];
                ServiceFactory.GetUserServices().ChangePassword(user.UserId, user.Password);
                return RedirectToAction("ShowConfirmation");
            }
            ViewBag.Error = null;
            ViewBag.Error = "Old password is not correct";
            return View();
        }
        [HttpGet]
        public ActionResult ShowConfirmation()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details()
        {
            return View(ServiceFactory.GetCompanyServices().Get((int)Session["CompanyId"]));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ServiceFactory.GetCompanyServices().Get((int)Session["CompanyId"]));
        }
        [HttpPost]
        public ActionResult Edit(Company c)
        {
            if(ValidateCompany.IsValid(c))
            {
                ServiceFactory.GetCompanyServices().Update(c);
                return RedirectToAction("Details");
            }
            else
            {
                ViewBag.Error = null;
                ViewBag.Error = ValidateCompany.Message;
                return View();
            }
        }
    }
}