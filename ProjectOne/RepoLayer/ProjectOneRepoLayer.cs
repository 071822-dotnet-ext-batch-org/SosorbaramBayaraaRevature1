using Models;
using ModelsLayer;
using System.Data.SqlClient;
using System.Numerics;

namespace RepoLayer;

public class ProjectOneRepoLayer
{
    /// <summary>
    /// #1 Login
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public async Task<LoginDto> LoginAsync(LoginDto login)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"SELECT UserName, Password FROM Employees WHERE UserName = @username AND Password = @password", conn1))
        {
            command.Parameters.AddWithValue("@username", login.UserName);
            command.Parameters.AddWithValue("@password", login.Password);
            conn1.Open();
            SqlDataReader ret = await command.ExecuteReaderAsync();

            if (ret.Read())
            {
                LoginDto login1 = new LoginDto(ret.GetString(0), ret.GetString(1));
                return login1;
            }
            conn1.Close();
            return null;
        }
    }
    /// <summary>
    /// #2 Register a new account
    /// </summary>
    /// <param name="newEmployee"></param>
    /// <returns></returns>
    public async Task<Employee> NewEmployeeAsync(Employee newEmployee)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"UPDATE Employees SET EmployeeID = @id, UserName = @user, FirstName = @fname, LastName = @lname, IsManager = @manager, Password = @pass WHERE UserName = @user IF @@ROWCOUNT = 0 INSERT INTO Employees (EmployeeID, UserName, FirstName, LastName, IsManager, Password) VALUES(@id, @user, @fname, @lname, @manager, @pass)", conn1))
        {
            command.Parameters.AddWithValue("@id", newEmployee.EmployeeID);
            command.Parameters.AddWithValue("@user", newEmployee.UserName);
            command.Parameters.AddWithValue("@fname", newEmployee.FirstName);
            command.Parameters.AddWithValue("@lname", newEmployee.LastName);
            command.Parameters.AddWithValue("@manager", newEmployee.IsManager);
            command.Parameters.AddWithValue("@pass", newEmployee.Password);

            conn1.Open();

            int ret = await command.ExecuteNonQueryAsync();

            if (ret > 0) //has to be 1 because if it is 0 it wont return anything
            {
                return newEmployee;
            }
            conn1.Close();
            return null;
        }
        
    }
    
    /// <summary>
    /// #3 Adding New Ticket
    /// </summary>
    /// <param name="newTicket"></param>
    /// <returns></returns>
    public async Task<Ticket> NewTicketAsync(Ticket newTicket)
    {
        SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand command = new SqlCommand($"INSERT INTO Tickets (TicketID, FK_EmployeeID, Description, Amount, Status) VALUES (@tid, @eid, @d, @a, @s);", conn1))
        {
            command.Parameters.AddWithValue("@tid", newTicket.TicketID);
            command.Parameters.AddWithValue("@eid", newTicket.FK_EmployeeID);
            command.Parameters.AddWithValue("@d", newTicket.Description);
            command.Parameters.AddWithValue("@a", newTicket.Amount);
            command.Parameters.AddWithValue("@s", newTicket.Status);

            conn1.Open();

            int ret = await command.ExecuteNonQueryAsync();

            if (ret == 1)
            {
                return newTicket;
            }
            conn1.Close();
            return null;
        }
    }
    
    /// <summary>
    /// #4 Updating ticket status
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
            int ret = await command.ExecuteNonQueryAsync(); //.ExecuteNonQuery sends raw SQL data to Db
            if (ret == 1)  // if it is false "Not a manager" then quit, if it is true then true
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
    /// <summary>
    /// #4 Ticket status updated by ID
    /// </summary>
    /// <param name="ticketID"></param>
    /// <returns></returns>
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
    /// <summary>
    /// #4 Confirms if the ID is a manager ID
    /// </summary>
    /// <param name="employeeID"></param>
    /// <returns></returns>
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

    /// <summary>
    /// #5 See tickets by status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
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


}

