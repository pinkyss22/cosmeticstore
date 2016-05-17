using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClothesStore1.DAL;
using ClothesStore1.Models;

namespace ClothesStore1.Controllers
{
    //[HandleError]
    public class CategoryController : Controller
    {
        //
        // GET: /Category/      
        public ActionResult Index()
        {
            //if (System.Web.HttpContext.Current.Session["user"] != null)
            //{
            CategoryDAL catDAL = new CategoryDAL();
            return View(catDAL.getAll());
            //}
            //return RedirectToAction("index","Home");

        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <returns></returns>        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                CategoryDAL catDAl = new CategoryDAL();
                if (catDAl.Create(cat))
                {
                    return RedirectToAction("Index", "Category");
                }
            }
            return View(cat);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            CategoryDAL catDAL = new CategoryDAL();
            if (catDAL.GetById(id) == null)
                return HttpNotFound();
            return View(catDAL.GetById(id));
        }
        /// <summary>
        /// Edit Confirm
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                CategoryDAL catDAL = new CategoryDAL();
                if (catDAL.EditConfirm(cat))
                {
                    return RedirectToAction("index");
                }
            }
            return View(cat);
        }

        /// <summary>
        /// Delte
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            CategoryDAL catDAL = new CategoryDAL();
            return View(catDAL.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryDAL catDAL = new CategoryDAL();
            if (ModelState.IsValid)
            {                
                if (catDAL.DeleteConfirm(id))
                    return RedirectToAction("index");
            }
            return View(catDAL.GetById(id));
        }
        public ActionResult ThrowException()
        {
            throw new ApplicationException();
        }

        public ActionResult CategoryPartial()
        {
            CategoryDAL catDAL = new CategoryDAL();
            return PartialView("_CategoryPartial", catDAL.getDb());
        }
    }
}
