using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClothesStore1.Models;

namespace ClothesStore1.DAL
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public string RoleId { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                var session = (User)HttpContext.Current.Session["user"];
                if (session != null)
                {
                    string userName = (User)session.UserName;
                    UserDAL uDAL = new UserDAL();

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            { 
                
            }
        }    
    }
}