using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1
{
    public class UserBLL
    {
        private UserDAL userDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public List<User> GetUsers() //this will get all the users
        {
            return userDAL.GetUsers();
        }

        public User GetUserByUsername(string username)
        {
            return userDAL.GetUserByUsername(username);
        }
    }
}