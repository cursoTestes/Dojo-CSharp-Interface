using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoInterfaceApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Bem-vindos ao Dojo de Interface, usando o wizard de projeto do VS2010";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
