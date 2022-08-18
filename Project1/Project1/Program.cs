using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        { 
            
            var arrUsers = new User[]
            {
                new User(1, "markmoore", "password1", "manager"),
                new User(2, "sambayaraa", "password2","employee")
            };

            Start:
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("\tHello! Welcome to the Employee Expense Reimbursement Application.");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("\tPress 1 to login or press 2 to register");
        var input = Console.ReadLine();


        bool successfull = false;
        while (!successfull)
        {
            if (input == "1")
            {
                Console.WriteLine("Please enter your username");
                var username = Console.ReadLine();
                Console.WriteLine($"Welcome {username}. Please enter your password");
                var password = Console.ReadLine();

                foreach (User user in arrUsers)
                {
                    if (username == user.username && password == user.password)
                    {
                        Console.WriteLine("You have successfully logged in!");
                        Console.ReadLine();
                        successfull = true;
                        break;
                    }
                }

                if (!successfull)
                {
                    Console.WriteLine("Your usernmane or password is incorrect, try again, please");
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Enter your username:");
                var username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                var password = Console.ReadLine();

                Console.WriteLine("Enter your role:");
                var role = Console.ReadLine();

                Console.WriteLine("Enter your id: ");
                int userID = int.Parse(Console.ReadLine());

                //Console.WriteLine("Please choose your role: 1 for manager and 2 for employee");
                //bool role = Console.ReadLine();

                Array.Resize(ref arrUsers, arrUsers.Length + 1);
                arrUsers[arrUsers.Length - 1] = new User(userID, username, password, role);
                successfull = true;
                goto Start;

            }
            else
            {
                Console.WriteLine("Try again !!");
                break;
            }
        } 
        //Console.WriteLine("Are you a returning user? Y/N?"); //from the user name we can identify is the user is admin or employe
            

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
