using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClothesStore1.Models;
using System.Data.Entity;

namespace ClothesStore1.DAL
{
    public class ProductStateDAL
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new CosmeticsDbEntities();
        public DbSet<ProductState> getAll()
        {
            return db.ProductStates;
        }
    }
}