using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        public bool IsValid(User user)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.IsValid(user);
        }
    }
}
