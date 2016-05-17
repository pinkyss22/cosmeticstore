using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClothesStore1.Models;
using System.Data;
using System.Web.Mvc;

namespace ClothesStore1.DAL
{
    public class ProductDAL
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new Models.CosmeticsDbEntities();
        /// <summary>
        /// Count product 
        /// </summary>
        /// <returns>quantity product</returns>
        public int Count()
        {
            return db.Products.Count();
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="ProductId">Product Id</param>
        /// <returns></returns>
        public Product GetProductById(int Id)
        {
            var product = db.Products.Find(Id);
            return product;
        }
        /// <summary>
        /// Get ALl product
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Product> GetAll(int page)
        {
            try
            {
                var list = db.Products.OrderByDescending(p => p.ProductId).ToList();
                return GetPageByLinq(10, page, list);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get product by category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        public IEnumerable<Product> ByCategory(int id)
        {
            try
            {
                var result = db.Products.Where(r => r.CategoryId == id).Select(r => r).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product object</returns>
        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }
        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="prodct"></param>
        /// <returns></returns>
        public bool Create(Product prodct)
        {
            db.Products.Add(prodct);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Confirm edit, save to databse
        /// </summary>
        /// <param name="prodct">product object</param>
        /// <returns></returns>
        public bool EditConfirmed(Product prodct)
        {
            db.Entry(prodct).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Confirm delete product from database
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        public bool DeleteConfirm(int id)
        {
            Product p = db.Products.Find(id);
            if (p != null)
            {
                db.Entry(p).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        ///  Update first image of product
        /// </summary>
        /// <param name="ProductId"> Product Id</param>
        /// <param name="ImagePath">image Path</param>
        /// <returns></returns>
        public bool UpdateImage(int ProductId, string ImagePath)
        {
            Product prod = db.Products.Find(ProductId);
            prod.mainImage = ImagePath;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Get product per page
        /// </summary>
        /// <param name="pageSize">quantity product in page</param>
        /// <param name="pageNum">page nunber</param>
        /// <param name="list">list product</param>
        /// <returns></returns>
        public List<Product> GetPageByLinq(int pageSize, int pageNum, List<Product> list)
        {
            var result = list.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            return result;
        }

        /// <summary>
        /// Feature product
        /// </summary>
        /// <returns></returns>
        public List<Product> Feature()
        {
            var result = db.Products.OrderByDescending(p => p.ProductId).Take(4).ToList();
            return result;
        }
        /// <summary>
        /// New product
        /// </summary>
        /// <returns></returns>
        public List<Product> NewProduct()
        {
            var result = db.Products.OrderByDescending(p => p.ProductId).Take(4).ToList();
            return result;
        }
        /// <summary>
        /// Best seller
        /// </summary>
        /// <returns></returns>
        public List<Product> BestSeller()
        {
            var result = db.Products.OrderByDescending(p => p.ProductSold).Take(4).ToList();
            return result;
        }

        //public List<Product> BestView()
        //{
        //    var result;
        //    return result;
        //}

        public List<Product> Sale()
        {
            var result = db.Products.Where(p => p.ProductSale > 0).OrderByDescending(pr => pr.ProductId).Take(4).ToList();
            return result;
        }
    }
}