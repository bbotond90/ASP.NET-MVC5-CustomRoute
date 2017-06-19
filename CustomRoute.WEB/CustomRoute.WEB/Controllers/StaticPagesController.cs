using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomRoute.WEB.Controllers
{
    public class StaticPagesController : Controller
    {
        public ActionResult Index(string staticPageName)
        {
            ViewBag.StaticPageName = staticPageName;

            //it must pass the name of the view
            return View(staticPageName);
        }
    }
}