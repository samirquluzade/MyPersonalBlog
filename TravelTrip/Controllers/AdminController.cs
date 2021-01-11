using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models;
using TravelTrip.Models.Classes;
namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var types = c.Blogs.ToList();
            return View(types);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NewBlogs(Blog b,HttpPostedFileBase imgfile)
        {
            Blog db = new Blog();
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
            {

            }
            else
            {
                db.Header = b.Header;
                db.Date = b.Date;
                db.Description = b.Description;
                db.BlogImage = path;
                c.Blogs.Add(db);
                c.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("UpdateBlog",blog);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdatesBlog(Blog b,HttpPostedFileBase imgfile) { 
        var blog = c.Blogs.Find(b.Id);
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
                   {

                    }
            else
            {
                blog.Description = b.Description;
                blog.Header = b.Header;
                blog.BlogImage = path;
                blog.Date = b.Date;
                c.SaveChanges();
            }
              
            return RedirectToAction("Index");
    }
        public ActionResult ListComments()
        {
            var comments = c.Comment.ToList();
            return View(comments);
        }
        public ActionResult DeleteComment(int id)
        {
            var blog = c.Comment.Find(id);
            c.Comment.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("ListComments");
        }
        public ActionResult ShowComment(int id)
        {
            var comment = c.Comment.Find(id);
            return View("ShowComment", comment);
        }
        public ActionResult UpdateComment(Comments b)
        {
            var comment = c.Comment.Find(b.Id);
            comment.UserName = b.UserName;
            comment.Mail = b.Mail;
            comment.Comment = b.Comment;
            c.SaveChanges();
            return RedirectToAction("ListComments");
        }
        public string uploadimage(HttpPostedFileBase imgfile)
         {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (imgfile != null && imgfile.ContentLength > 0)
            {
                string extension = Path.GetExtension(imgfile.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(imgfile.FileName));
                        imgfile.SaveAs(path);
                        path = "Content/upload/" + random + Path.GetFileName(imgfile.FileName);
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please');</script>");
                path = "-1";
            }
            return path;
        }
    }
}