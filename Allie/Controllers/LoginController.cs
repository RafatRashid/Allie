using Allie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Session["LoggedIn"] = true;
                Session["UserMail"] = log.UserMail;

                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index");
        }
    }
}