using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        // entry point of the program...

        /*either users can login or new entrepreneurs or businessowners can
        register their business company for allie services...*/

        public ActionResult Index()
        {
            return View();
        }
    }
}