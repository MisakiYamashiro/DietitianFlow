using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DietitianFlow.Filters
{
    public class AdminAuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var session = HttpContext.Current.Session;

            if (session["Admin"] == null && session["Dietitian"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
        }
    }
}