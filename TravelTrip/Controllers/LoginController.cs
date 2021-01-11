using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Models.Classes;
namespace TravelTrip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Models.Classes.Context c = new Models.Classes.Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var information = c.Admins.FirstOrDefault(x => x.User == ad.User && x.Password == ad.Password);
            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.User,false);
                Session["User"] = information.User.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}