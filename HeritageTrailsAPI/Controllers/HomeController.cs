using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageTrailsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Heritage Trails API";

            return View();
        }

        public ActionResult AddTrail()
        {
            ViewBag.Title = "Heritage Trails API - Add trail";

            return View();
        }

        public ActionResult AddStop()
        {
            ViewBag.Title = "Heritage Trails API - Add stop";

            return View();
        }

        public ActionResult AddDetailStop()
        {
            ViewBag.Title = "Heritage Trails API - Add detail stop";

            return View();
        }
    }
}
