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
                ICompanyServices compService = ServiceFactory.GetCompanyServices();
                compService.Insert(c);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = ValidateCompany.Message;
                return View();
            }
        }
    }
}