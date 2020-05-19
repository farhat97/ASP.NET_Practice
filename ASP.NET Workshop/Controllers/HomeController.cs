using System;
using System.Web.Mvc;

namespace ASP.NET_Workshop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Session["MyTimeSession"] = DateTime.Now.ToString(); // survives the entire session
            TempData["MyTimeTemp"] = DateTime.Now.ToString(); // survives per request
            ViewBag.MyTime = DateTime.Now.ToString();
            return RedirectToAction("GoToHome", "Home");
        }

        public ActionResult GoToHome()
        {
            // pass data to home page
            // passing data from controller to view is with ViewData or ViewBag
            // ViewData["MyTime"] = DateTime.Now.ToString();

            // ViewBag simplifies the syntax but it is dynamic
            ViewBag.MyTime = DateTime.Now.ToString();

            return View("MyHomePage");
        }
    }
}