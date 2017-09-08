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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        /*the following 2 create method displays the form for creating a new company and
         handling the company data. Post method stores the company in session and passes 
         to user controller for making owner.*/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Company c)
        {
            if(ValidateCompany.IsValid(c))
            {
                Session["Company"] = c;
                return RedirectToAction("CreateOwner", "User");
            }
            else
            {
                ViewBag.Error = ValidateCompany.Message;
                return View();
            }
        }
    }
}