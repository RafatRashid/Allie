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
    public class HomeController : Controller
    {
        // GET: Home
        // entry point of the program...

        /*either users can login or new entrepreneurs or businessowners can
        register their business company for allie services...*/

        public ActionResult Index()
        {
            return View();
        }

        /*the following 2 create method displays the form for creating a new company and
         handling the company data. Post method stores the company in session and passes 
         to next 2 methods for making owner.*/
        [HttpGet]
        public ActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCompany(Company c)
        {
            if (ValidateCompany.IsValid(c))
            {
                Session["Company"] = c;
                return RedirectToAction("CreateOwner");
            }
            else
            {
                ViewBag.Error = ValidateCompany.Message;
                return View();
            }
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
            if (ValidateUser.IsValid(u))
            {
                u.UserType = ServiceFactory.GetUserTypeServices().Get("Owner").Id;
                Company c = (Company)Session["Company"];
                ServiceFactory.GetCompanyServices().Insert(c);
                u.CompanyId = c.CompanyId;

                ServiceFactory.GetUserServices().Insert(u);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = ValidateUser.Message;
                return View();
            }
        }
    }
}