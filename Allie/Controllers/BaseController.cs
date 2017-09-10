using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allie.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // setting a dummy company id in the session for the time being. this will be set during log in
            // for differentiating between company account, transaction, ledger etc. 5 is the only company's id
            // that is present in the database...
            Session["CompanyId"] = 1;   

            //if (Session["loggedIn"] == null)
            //    Response.Redirect("/Login/Index");
        }
    }
}