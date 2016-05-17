using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore1.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Eror 404
        /// </summary>
        /// <returns></returns>
        public ActionResult Error404()
        {
            return View();
        }
        /// <summary>
        /// Error 401
        /// </summary>
        /// <returns></returns>
        public ActionResult Error401() 
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 401;  //you may want to set this to 200
            return View("NotFound");
        }
    }
}
