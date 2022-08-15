using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1
{
    public class User
    {
        public string username;
        public string password;
        public int userID;
        public string role;

        public User(int userID, string username, string password, string role)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }
}