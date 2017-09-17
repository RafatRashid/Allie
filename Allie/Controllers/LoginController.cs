//using Allie.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Allie.Controllers
//{
//    public class LoginController : Controller
//    {
//        // GET: Login
//        [HttpGet]
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Index(LogIn log)
//        {
//            if (LogIn.Validate(log))
//            {
//                Session["LoggedIn"] = true;
//                Session["UserMail"] = log.UserMail;

//                return RedirectToAction("Index", "Home");
//            }
//            else
//                return RedirectToAction("Index");
//        }
//    }
//}

using Allie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllieService;
using AllieEntity;

namespace Allie.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LogIn log)
        {
            if (LogIn.Validate(log))
            {
                User user = ServiceFactory.GetUserServices().Get(log.UserMail, log.Password);
                if (user == null) { ViewBag.ErrorMessage = "Username not found"; }
                else
                {
                    Session["LoggedIn"] = true;
                    Session["UserId"] = user.UserId;
                    Session["UserName"] = user.UserName;
                    Session["Email"] = user.Email;
                    Session["CompanyId"] = user.CompanyId;

                    UserType type = ServiceFactory.GetUserTypeServices().Get(user.UserType);

                    if (type.Type == "Owner")
                    {
                        Session["UserType"] = "Owner";
                        return RedirectToAction("Index", "Company");
                    }
                    else
                    {
                        Session["UserType"] = "SuperAdmin";
                        return RedirectToAction("Index", "Admin");
                    }
                }
                return View();
            }
            ViewBag.ErrorMessage = null;
            ViewBag.ErrorMessage = "Incorrect username or password";

            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session["LoggedIn"] = null;
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["Email"] = null;
            Session["CompanyId"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}