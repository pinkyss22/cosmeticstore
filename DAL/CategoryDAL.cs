using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using System.Data.Entity;

namespace DAL
{
    public class CategoryDAL
    {
        private BOL.CosmeticsDbEntities db = new CosmeticsDbEntities();
        public IEnumerable<Category> getAll()
        {
            try
            {
                IEnumerable<Category> cat = db.Categories.ToList<Category>();
                return cat;
            }
            catch (Exception ex)
            {
                throw new Exception("Không lấy được dữ liệu");
            }            
        }
        //public bool Create(Category Cat)
        //{
        //    //if(.State)
        //    //return true;
        //}
    }
}
