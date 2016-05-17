using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClothesStore1.Models;

namespace ClothesStore1.DAL
{
    public class UserDAL
    {
        private ClothesStore1.Models.CosmeticsDbEntities db = new CosmeticsDbEntities();
        /// <summary>
        /// Get RoleName by userName 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetRoleName(string userName)
        {
            try
            {
                var result = (from u in db.Users
                              join r in db.Roles on u.UserRoleId equals r.RoleId
                              where u.UserName == userName
                              select new
                              {
                                  r.RoleName
                              }).ToList();

                return result[0].RoleName as string;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// check Valid when login
        /// </summary>
        /// <param name="user">objec user</param>
        /// <returns>true/false</returns>
        public bool IsValid(User user)
        {
            List<User> temp = db.Users.Where(u => u.UserName == user.UserName).ToList();
            if (temp.Count != 0)
            {
                if (user.UserPassword == temp[0].UserPassword)
                    return true;
            }
            return false;
        }
        public bool Create(User user)
        {
            return true;
        }
        public bool Delete(int Id)
        {
            return true;
        }
        public bool Edit(int Id)
        {
            return true;
        }
    }
}