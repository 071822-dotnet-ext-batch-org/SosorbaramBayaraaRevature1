

namespace Models;
public class NewEmployee
{

  
    public NewEmployee(string v1, string v2, string v3, int v4, string v5)
    {
        V1 = v1;
        V2 = v2;
        V3 = v3;
        V4 = v4;
        V5 = v5;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsManager { get; set; }
    public string V1 { get; }
    public string V2 { get; }
    public string V3 { get; }
    public int V4 { get; }
    public string V5 { get; }
}
