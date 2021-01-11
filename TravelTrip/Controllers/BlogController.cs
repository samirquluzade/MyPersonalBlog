using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.Classes;
namespace TravelTrip.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment type = new BlogComment();
        public ActionResult Index()
        {
            type.type1 = c.Blogs.ToList();
            type.type3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            type.type4 = c.Comment.Take(5).ToList();
            return View(type);
        }
        
        public ActionResult BlogDetal(int id)
        {
            type.type1 = c.Blogs.Where(x => x.Id == id).ToList();
            type.type2 = c.Comment.Where(x => x.BlogId == id).ToList();
            type.type4 = c.Comment.Take(5).ToList();
            type.type5 = c.Blogs.Take(3).ToList();
            return View(type);
        }
        [HttpGet]
        public PartialViewResult WriteComment(int id)
        {
            ViewBag.type = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult WriteComment(Comments b)
        {
            c.Comment.Add(b);
            c.SaveChanges();
            Response.Redirect(Request.Url.ToString(), false);
            return PartialView();
        }
    }
}