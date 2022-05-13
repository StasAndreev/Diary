using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // For database initialisation
            DiaryContext db = new DiaryContext();
            db.Dispose();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
