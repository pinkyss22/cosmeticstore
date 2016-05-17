using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClothesStore1.Models;
using ClothesStore1.DAL;

namespace ClothesStore1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                ClothesStore1.DAL.UserDAL uDAL = new UserDAL();
                if (uDAL.IsValid(user))
                {
                    HttpContext.Session["user"] = user;
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                    ViewData["error"] = "Đăng nhập thất bại";
                }

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }
}
