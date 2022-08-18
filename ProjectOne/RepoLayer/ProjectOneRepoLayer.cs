using ModelsLayer;
using System.Data.SqlClient;
using System.Numerics;

namespace RepoLayer;

    public class ProjectOneRepoLayer
    {
        public async Task<List<Ticket>> TicketsAsync(int status)
        {
               // made a connection wusing Sql connection class
            SqlConnection conn1 = new SqlConnection("Server=tcp:revature.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=samRevature;Password=Hulanlove23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Ticket WHERE Status = @status", conn1)) //created a command using the query and the connection string
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
                return tList;
            }
        }
    }  

