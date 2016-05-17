using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClothesStore1.Models;
using System.Data;
using System.Data.Entity;
using System.IO;

namespace ClothesStore1.DAL
{
    public class ImagesInforDAL
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new CosmeticsDbEntities();

        public List<ImageInfor> getByProduct(int id)
        {
            return db.ImageInfors.Where(i => i.ProductId == id).ToList();
        }
        /// <summary>
        /// Save path of image to ImageInfor table
        /// </summary>
        /// <param name="ProductId">int</param>
        /// <param name="file">HttpPostedFileBase</param>
        /// <returns></returns>
        public bool SavePath(int ProductId, HttpPostedFileBase file)
        {
            ImageInfor img = new ImageInfor();
            img.ProductId = ProductId;
            img.ImagePath = "/Content/images/products/" + file.FileName;
            db.ImageInfors.Add(img);
            db.SaveChanges();
            return true;
        }

        public string GetMainImage(int productId)
        {
            ImageInfor img = db.ImageInfors.Where(i => i.ProductId == productId).OrderByDescending(i=>i.ImageInforId).FirstOrDefault();
            if (img != null)
            {
                return img.ImagePath;
            }            
            return null;            
        }
    }
}