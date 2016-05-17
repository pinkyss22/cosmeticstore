using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ClothesStore1.DAL
{
    public class MyAuthorize : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult(500, "You are not authorized to view the application.");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}