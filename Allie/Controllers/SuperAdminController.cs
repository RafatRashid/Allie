using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class SuperAdminController : Controller
    {
        // GET: SuperAdmin
        /*the view that the super admin of allie will get.*/
        public ActionResult Index()
        {
            return View();
        }
    }
}