namespace Models;
public class Employee
{
    public Guid EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsManager { get; set; }
}
