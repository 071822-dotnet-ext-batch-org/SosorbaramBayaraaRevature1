using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Project1
{
    public class UserDAL
    {
        private List<User> users; //this will get all the users
        
        public UserDAL()
        {
            //mock users
            users = new List<User>()
            {
                new User { Username = "markmoore", Role = true }, // true == manager, false == employee
                new User { Username = "sambayaraa", Role = false},
                new User { Username = "johnsmith", Role = false}
            };    
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public User GetUserByUsername(string username)
        {
            var user = users.FirstOrDefault(u => u.Username.Equals(username));
            
            return user;
        }
    }
}