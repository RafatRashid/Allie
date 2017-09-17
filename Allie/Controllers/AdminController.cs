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
    public class AdminController : AdminBaseController
    {
        ICompanyServices service = ServiceFactory.GetCompanyServices();
        IUserServices uService = ServiceFactory.GetUserServices();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Company> comp = ServiceFactory.GetCompanyServices().GetAll();
            return View(comp);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            IEnumerable<User> userlist = uService.GetCompanyUsers(id);
            Company com = service.Get(id);
            ViewBag.CompanyDetails = com;
            return View(userlist);
        }
        
    }
}