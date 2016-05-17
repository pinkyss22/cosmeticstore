using ClothesStore1.DAL;
using ClothesStore1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore1.Controllers
{
    public class ProductController : Controller
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new CosmeticsDbEntities();
        //
        // GET: /Product/page =1
        public ActionResult Index(int page = 1)
        {
            ProductDAL prodctDAL = new ProductDAL();
            CategoryDAL catDAL = new CategoryDAL();
            ViewBag.CatId = new SelectList(catDAL.getAll(), "CategoryId", "CategoryName");
            ViewBag.Sum = prodctDAL.Count().ToString();
            return View(prodctDAL.GetAll(page));
        }
        //
        //POST: /product/category/page
        [HttpPost]
        public ActionResult Index(string CategoryId, int page = 1)
        {
            CategoryDAL cDAL = new CategoryDAL();
            ViewBag.CatId = new SelectList(cDAL.getAll(), "CategoryId", "CategoryName");
            ProductDAL pDAL = new ProductDAL();           

            if (CategoryId != "")
            {
                ViewBag.Sum = pDAL.ByCategory(int.Parse(CategoryId)).Count().ToString();
                return View(pDAL.ByCategory(int.Parse(CategoryId)));
            }
            ViewBag.Sum = pDAL.Count().ToString();
            return View(pDAL.GetAll(page));
        }
        //
        // Create: /Create
        public ActionResult Create()
        {
            CategoryDAL catDAL = new CategoryDAL();

            ViewBag.CatId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        //
        //POST: /Create
        [HttpPost]
        public ActionResult Create(Product product, List<HttpPostedFileBase> file)
        {
            if (ModelState.IsValid)
            {
                ProductDAL prodDAL = new ProductDAL();
                ImagesInforDAL imgDAL = new ImagesInforDAL();

                if (prodDAL.Create(product))
                {
                    if (UploadImage(product.ProductId, file))
                    {
                        prodDAL.UpdateImage(product.ProductId, imgDAL.GetMainImage(product.ProductId));
                        return RedirectToAction("index");
                    }

                }
            }
            ViewBag.CatId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(product);
        }
        //
        //Bool: updaloet image
        public bool UploadImage(int ProductId, List<HttpPostedFileBase> file)
        {
            foreach (var item in file)
            {
                var fileName = item.FileName;
                string filePath = Path.Combine(HttpContext.Server.MapPath("/Content/Images/products/"), Path.GetFileName(item.FileName));
                if (filePath.Count() != 0)
                {
                    item.SaveAs(filePath);
                    ImagesInforDAL imgDAL = new ImagesInforDAL();
                    imgDAL.SavePath(ProductId, item);
                }
            }
            return true;
        }
        //
        // GET: /Edit/1
        public ActionResult Edit(int Id = 0)
        {
            ProductDAL pDAL = new ProductDAL();
            CategoryDAL catDAL = new CategoryDAL();

            ViewBag.CatId = new SelectList(catDAL.getAll(), "CategoryId", "CategoryName");
            if (pDAL.GetProductById(Id) == null)
                return HttpNotFound();
            return View(pDAL.GetProductById(Id));
        }
        //
        //POST: /Edit/1
        [HttpPost]
        public ActionResult Edit(Product p, List<HttpPostedFileBase> file)
        {

            if (ModelState != null)
            {
                ProductDAL pDAL = new ProductDAL();
                if (file[0] != null)
                {
                    UploadImage(p.ProductId, file);
                }
                ImagesInforDAL iDAL = new ImagesInforDAL();
                p.mainImage = iDAL.GetMainImage(p.ProductId);
                pDAL.EditConfirmed(p);
                return RedirectToAction("Index");
            }
            CategoryDAL catDAL = new CategoryDAL();
            ViewBag.CatId = new SelectList(catDAL.getAll(), "CategoryId", "CategoryName");
            return View(p);
        }
        //
        //GET: /Delete/1
        public ActionResult Delete(int id)
        {
            ProductDAL pDAL = new ProductDAL();
            return View(pDAL.GetProductById(id));
        }
        //
        //POST: /delete/1
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState != null)
            {
                ProductDAL productDAL = new ProductDAL();
                if (productDAL.DeleteConfirm(id))
                {
                    return RedirectToAction("index");
                }
            }
            ProductDAL prodDAL = new ProductDAL();
            return View(prodDAL.GetProductById(id));
        }
        //
        //GET: Detail/1
        public ActionResult Detail(int id)
        {
            if (ModelState.IsValid)
            {
                ProductDAL pDAL = new ProductDAL();
                return View(pDAL.GetById(id));
            }
            return View();
        }
        //
        //GET: partial
        public ActionResult FeatureProduct()
        {
            ProductDAL pDAL = new ProductDAL();
            return PartialView("_FeaturePartial", pDAL.Feature());
        }
        public ActionResult NewProduct()
        {
            ProductDAL pDAL = new ProductDAL();
            return PartialView("_NewPartial", pDAL.NewProduct());
        }
        public ActionResult BestSeller()
        {
            ProductDAL pDAL = new ProductDAL();
            return PartialView("_BestSellerPartial", pDAL.BestSeller());
        }
        public ActionResult Sale()
        {
            ProductDAL pDAL = new ProductDAL();
            return PartialView("_SalePartial", pDAL.Sale());
        }
    }
}
