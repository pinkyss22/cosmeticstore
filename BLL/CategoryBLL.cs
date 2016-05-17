using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class CategoryBLL
    {
        public IEnumerable<Category> getAll()
        {
            CategoryDAL catDAL = new CategoryDAL();
            return catDAL.getAll();
        }
    }
}
