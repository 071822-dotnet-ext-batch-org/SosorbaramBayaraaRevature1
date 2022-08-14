using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1
{
    public class User
    {

        //A class has Properties, attributes, constructors, and methods (mainly)

        //an attribute is a single piece of a data like age, DoB, name, etc
            // Attributes: has an acces modifier controls what parts of code can access a specific class or field (or property, or method)
        //A property is a special C# abstraction that is a combination of a GETTER and a SETTER and the data that they get and set
        //USER ID (attribute)
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; } //true  == manager, false == employee
       
        // Constructors are the methods called to instantiate and initialize a class object. These can be overloaded
                //If you create parameterized constructor, you must create your own default constructor
                //You are automatically given a default constructor
        private string fName;
        private string lName;
        private string username;
        private string password;
        private string userID;

        // methods are sets of consecutive steps that the porogram copletes. the can be called individually
            //getter and setter methods get/set the data while protecting the data
       

        
    }
}