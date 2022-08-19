using Models;
using ModelsLayer;
using System.Data.SqlClient;
using System.Numerics;

namespace RepoLayer;

public class ProjectOneRepoLayer
{
    public async Task<Employee> NewEmployeeAsync(Guid employeeID,string userName, string firstName, string lastName, bool isManager, string pasword)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using SqlCommand command = new SqlCommand($"INSERT INTO Employees (employeeID, userName, firstName, lastName, isManager, password) VALUES (@employeeID, @username, @firstname, @lastname, @isManager, @password)", conn1); //created a command using the query and the connection string,
        {
            command.Parameters.AddWithValue("@employeeID", employeeID);
            command.Parameters.AddWithValue("@username", userName); //I gave parameter to the command
            command.Parameters.AddWithValue("@firstname",firstName);
            command.Parameters.AddWithValue("@lastname", lastName );
            command.Parameters.AddWithValue("@isManager", isManager );
            command.Parameters.AddWithValue("@password", pasword );
       
            conn1.Open();                                   // opening connection
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read()) //advances to the first row  // if it is false "Not a manager" then quit, if it is true then true
            {
                Employee e = new Employee(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetBoolean(4), ret.GetString(5));

                conn1.Close();
                return e;
            }
            conn1.Close();
            return null;
        }
    }

    public async Task<List<Ticket>> TicketsAsync(int status)
    {
        // made a connection wusing Sql connection class
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE Status = @status", conn1)) //created a command using the query and the connection string,
        {
            command.Parameters.AddWithValue("@status", status); //I gave parameter to the command
            conn1.Open();                                   // opening connection
            SqlDataReader? ret = await command.ExecuteReaderAsync(); //Reding data from the db, (read only)
            List<Ticket> tList = new List<Ticket>(); //creating list as empty list naming it tList

            while (ret.Read()) //advances to the first row
            {
                Ticket t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                tList.Add(t);
            }
            conn1.Close();
            return tList;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="employeeID"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<UpdatedTicketDto> UpdateTicketAsync(Guid ticketID, int status)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"UPDATE Tickets SET Status = @status WHERE TicketID = @id", conn1)) //created a command using the query and the connection string,
        {
            command.Parameters.AddWithValue("@id", ticketID); //I gave parameter to the command
            command.Parameters.AddWithValue("@status", status);
            conn1.Open();                                   // opening connection
            int ret = await command.ExecuteNonQueryAsync(); //.ExecuteNonQuery
            if (ret == 1) //advances to the first row  // if it is false "Not a manager" then quit, if it is true then true
            {
                conn1.Close();
                //Call the request by ID()
                //Create 2 new branches to get the request by
                //ID and get the employee by id. There are methods that should be useful and reusable.

                //call the UpdatedRequestByID(). this method will use a join to return the Employee name along with the relevant details and return a DTO so that
                // the FE can display the updated data to the user
                UpdatedTicketDto urbi = await this.UpdatedTicketByIDAsync(ticketID);


                
                return urbi;
            }
            conn1.Close();
            return null;
        }
    }

    private async Task<UpdatedTicketDto> UpdatedTicketByIDAsync(Guid ticketID)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT TicketID, FirstName, LastName, Status FROM [dbo].[Employees] LEFT JOIN Tickets ON EmployeeID = FK_EmployeeID WHERE TicketID = @ticketID", conn1)) //created a command using the query and the connection string,
        {
            command.Parameters.AddWithValue("@ticketID", ticketID); //I gave parameter to the command
            conn1.Open();                                   // opening connection
            SqlDataReader? ret = await command.ExecuteReaderAsync(); //Using ? because what if it returns nothing
            if (ret.Read()) 
            {
                UpdatedTicketDto t = new UpdatedTicketDto(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3));
                conn1.Close();
                return t;
            }
            conn1.Close();
            return null;
        }
    }

    public async Task<bool> IsManagerAsync(Guid employeeID)
    {
            // made a connection wusing Sql connection class
            SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT IsManager FROM Employees WHERE EmployeeID = @id", conn1)) //created a command using the query and the connection string,
            {
                command.Parameters.AddWithValue("@id", employeeID); //I gave parameter to the command
                conn1.Open();                                   // opening connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); //Reding data from the db, (read only)  
                if (ret.Read() && ret.GetBoolean(0)) //advances to the first row  // if it is false "Not a manager" then quit, if it is true then true
                {
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                return false;
            }

        
    }

    public async Task<List<LoginDto>> LoginAsync(string firstName, string lastName, string userName, string password)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Employees WHERE FirstName = @fname, LastName = @lname", conn1)) //created a command using the query and the connection string,
        {
            command.Parameters.AddWithValue("@", status); //I gave parameter to the command
            conn1.Open();                                   // opening connection
            SqlDataReader? ret = await command.ExecuteReaderAsync(); //Reding data from the db, (read only)
            List<Ticket> tList = new List<Ticket>(); //creating list as empty list naming it tList

            while (ret.Read()) //advances to the first row
            {
                Ticket t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));
                tList.Add(t);
            }
            conn1.Close();
            return tList;
        }
    }
}

