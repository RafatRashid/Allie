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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        /*the following 2 methods create an owner creation form and inserts both the company and
         owner. This was done so that both the company and its owner can be registered simultaneously.*/
        [HttpGet]
        public ActionResult CreateOwner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOwner(User u)
        {
            if(ValidateUser.IsValid(u))
            {
                u.UserType = ServiceFactory.GetUserTypeServices().Get("Owner").Id;
                Company c = (Company)Session["Company"];
                ServiceFactory.GetCompanyServices().Insert(c);
                u.CompanyId = c.CompanyId;
                
                ServiceFactory.GetUserServices().Insert(u);
                return RedirectToAction("Index", "Company");
            }
            else
            {
                ViewBag.Error = ValidateUser.Message;
                return View();
            }
        }
    }
}