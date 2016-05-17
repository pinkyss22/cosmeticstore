using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

using ClothesStore1.Models;
using System.Web.Mvc;

namespace ClothesStore1.DAL
{
    public class CategoryDAL
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new CosmeticsDbEntities();

        /// <summary>
        /// get All information in Category
        /// </summary>
        /// <returns></returns>
        public DbSet<Category> getAll()
        {
            return db.Categories;
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="cat">Category Object</param>
        /// <returns></returns>
        public bool Create(Category cat)
        {
            try {
                db.Categories.Add(cat);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
           
        }
        public DbSet<Category> getDb()
        {
            return db.Categories;
        }
        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        public Category GetById(int id) 
        {
            Category cat = db.Categories.Find(id);
            return cat;
        }
        /// <summary>
        /// Edit Confirm
        /// </summary>
        /// <param name="cat">Category object</param>
        /// <returns></returns>
        public bool EditConfirm(Category cat)
        {
            try
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch{}
            return true;
        }
        /// <summary>
        /// Delete Confirm
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns></returns>
        public bool DeleteConfirm(int id)
        {
            try
            {
                db.Categories.Remove(db.Categories.Find(id));
                db.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }
     }
}