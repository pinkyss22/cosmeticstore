using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class UserDAL
    {
        BOL.CosmeticsDbEntities db = new CosmeticsDbEntities();
        public List<User> GetAll()
        {
            List<User> Users = db.Users.ToList();
            return Users;
        }
        /// <summary>
        /// Valid Login
        /// </summary>
        /// <returns></returns>
        public bool IsValid(User user)
        {
            bool isValid = false;
            var temp = db.Users.Where(u => u.UserName == user.UserName).ToList();
            if(temp.Count != 0 )
            {
                if (user.UserPassword == temp[0].UserPassword)
                    isValid = true;
            }
            return isValid;
        }
    }
}
