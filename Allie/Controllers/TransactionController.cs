using AllieService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
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
        public ActionResult Create(FormCollection form)
        {
            return View();
        }

    }
}