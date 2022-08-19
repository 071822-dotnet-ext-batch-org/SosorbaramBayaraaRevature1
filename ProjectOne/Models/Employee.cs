namespace Models;
public class Employee
{
    public Employee(Guid employeeID, string firstName, string lastName, string userName, bool isManager, string password)
    {
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Password = password;
        IsManager = isManager;
    }


    public Guid EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsManager { get; set; }

    
}
