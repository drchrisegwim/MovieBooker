using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]   // This attribute overides authorization for ananymous users
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 50)]  // This is how to enable cache 
        public ActionResult About()
        {
            throw new Exception();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}