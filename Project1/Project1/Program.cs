using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
             //power to choose to be a manager or employee   
            //have an option to create a username and password 

            Console.WriteLine("\tHello! Welcome to the Employee Expense Reimbursement Application.");


            string username = "";
            string password = "";

            Console.WriteLine("\n\tPlease enter your username"); //from the user name we can identify is the user is admin or employee
            
            username = Console.ReadLine();


            Console.WriteLine($"Hi {username} "); //needs to identify whether its Manager or Employee later

            Console.WriteLine("Please enter your password");

            // check the password is valid or not

            password = Console.ReadLine();

            if(true)
            {
    
            }
            else
            Console.WriteLine("Invalid username or password");


        
        //User must sign in. System will distingquish whether the user is a manager or employee by the username
        
        //EMPLOYEE
        /*
        Logged in Employee will be able to add  reimbursement. once the reimbursement is added it will be available
        for Managers to see the PENDING request*/
        //Logged-in Employee will be able to view past tickects (APPROVED OR DENIED) or Pending tickets
        //MUST be able to see the updated status

        //MANAGER
        //Must be able to veiw all PENDING reimnursement for all employees
        //IF the request MEETS COMPANY RULES: YES/APPROVE or NO/DENY
        //Must be able to APPROVE/DENY reimbursement
        //Must be able to filter request by STATUS
        

        //STATUSES
        //PENDING
        //APPROVED
        //DENIED







        }//main
    }//class
}//namespace
