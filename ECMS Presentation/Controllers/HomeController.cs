using ECMS_Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECMS_Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            UserManager um = new UserManager();
            if(um.AuthenticateUser(username, password))
            {
                Session["username"] = username;
                FormsAuthentication.SetAuthCookie(username, false);
                return Redirect(Url.Action("Index", "Dashboard"));
            }
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Models.RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                UserManager um = new UserManager();
                um.RegisterUser(rvm.Username, rvm.Password, rvm.PhoneNumber);
                ViewBag.status = "success";
                return View("RegistrationStatus");
            }
            ViewBag.status = "failed";
            return View("RegistrationStatus");
        }

        public ActionResult Logoff()
        {
            Session["username"] = null;
            return View("Index");
        }
    }
}