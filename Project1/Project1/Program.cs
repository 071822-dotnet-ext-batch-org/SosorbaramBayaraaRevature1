using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

        Console.WriteLine("**********************************************************************");
        Console.WriteLine("\tHello! Welcome to the Employee Expense Reimbursement Application.");
        Console.WriteLine("**********************************************************************");
            
        //Console.WriteLine("Are you a returning user? Y/N?"); //from the user name we can identify is the user is admin or employee
        Console.WriteLine("Please enter your username");
        user.Username = Console.ReadLine();

        Console.WriteLine($"Welcome {user.Username}. Please enter your password");
        user.Password = Console.ReadLine();
           
            while (true) //this loop is beginning of the application
            {
                
            }
            

           //create instance of a User class

          /*  
          username = Console.ReadLine();


            Console.WriteLine($"Hi {username} "); //needs to identify whether its Manager or Employee later

            Console.WriteLine("Please enter your password");

            // check the password is valid or not

            password = Console.ReadLine();

            if(password == "password")
            {
                Console.WriteLine($"Welcome {username}");
            
            }
            else
            Console.WriteLine("Invalid username or password. Please try again.");
        */
        

        
        //Create a new username and password
        
        //EMPLOYEE
        // Must be able to login
        // Must be able to see the past tickets
        // Must be able to add reimbursment request

        //MANAGER
        // Must be able to login
        // Must be able to View all reimbursment for all EMPLOYEES
        // Must be able to filter requists by STATUS
        // Must be able to approv/deny reimbursments

        }//main
    }//EoC
}//EoS
