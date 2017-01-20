using ECMS_Business_Logic;
using ECMS_Data_Models;
using ECMS_Presentation.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMS_Presentation.Controllers
{
    [SessionAuthorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateMeeting()
        {
            return Content("create meeting");
        }
        public ActionResult EditProfile()
        {
            User u = new UserManager().GetUserByUsername(Session["username"].ToString());
            return PartialView("_EditProfile", u);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(FormCollection collection)
        {
            UserManager umgr = new UserManager();
            User u = umgr.GetUserByUsername(Session["username"].ToString());
            try
            {
                u.UserName = collection["UserName"];
                u.Password = collection["Password"];
                u.PhoneNumberPrimary = long.Parse(collection["PhoneNumberPrimary"]);
                umgr.UpdateUser(u);
                //return JavaScriptResult(new JavaScriptResult { Script = "" },);
                //return JavaScript(" <script>  </script>");
                //return PartialView("_EditProfile", u);
                return Content("success");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());

                return Content("failed");
            }
            
        }
    }
}