using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.Classes;
namespace TravelTrip.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Models.Classes.Context c = new Models.Classes.Context();
        public ActionResult Index()
        {
            var types = c.Blogs.ToList();
            return View(types);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var types = c.Blogs.OrderByDescending(x => x.Id).Take(2).ToList();
            return PartialView(types);
        }
        public PartialViewResult Partial2()
        {
            var types = c.Blogs.Where(x => x.Id == 1).ToList();
            return PartialView(types);
        }
        public PartialViewResult Partial3()
        {
            var types = c.Blogs.Take(10).ToList();
            return PartialView(types);
        }
        public PartialViewResult Partial4()
        {
            var types = c.Blogs.Take(3).ToList();
            return PartialView(types);
        }
        public PartialViewResult Partial5()
        {
            var types = c.Blogs.Take(3).OrderByDescending(x => x.Id).ToList();
            return PartialView(types);
        }
        public ActionResult Destination()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}