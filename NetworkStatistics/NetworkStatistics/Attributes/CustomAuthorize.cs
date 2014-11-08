using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkStatistics.Attributes
{
    using System.Web.Mvc;

    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           filterContext.Result = new RedirectResult("~/Home/Unauthorized");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}