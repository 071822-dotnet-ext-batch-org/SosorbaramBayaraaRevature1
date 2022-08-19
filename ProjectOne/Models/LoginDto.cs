using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class LoginDto
    {
        public LoginDto(string userName,string password)
        {
            UsernName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;

        }

        
   
      

        public string UsernName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    

    }
}
