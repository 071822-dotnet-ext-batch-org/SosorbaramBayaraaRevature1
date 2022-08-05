using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;




namespace SQL
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Assumes connectionString is a valid connection string.  
            using (SqlConnection connection = new SqlConnection(""))  
            {  
                connection.Open();
                // Do work here.  
                SqlCommand command = new SqlCommand("SELECT * from dbo.Customer", connection);
                SqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    Console.WriteLine($"{myReader.GetInt32(0)} \t\t{myReader.GetString(1)}");
                }

                connection.Close();
            } 
        }
    }

}
