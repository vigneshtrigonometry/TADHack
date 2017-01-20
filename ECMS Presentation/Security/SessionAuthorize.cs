using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMS_Presentation.Security
{
    public class SessionAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["username"] == null||HttpContext.Current.Session["username"].ToString() == "")
                return false;
            else
                return true;
        }
    }
}