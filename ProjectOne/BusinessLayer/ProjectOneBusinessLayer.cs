using Models;
using ModelsLayer;
using RepoLayer;

namespace BusinessLayer;
public class ProjectOneBusinessLayer
{
    // "_businessLayer" naming convention for private local variables. 
    // this is a business layer Entity, the instance of the Business layer. Using this to call the method
    //It is using "Private" because it is protecting from calling it from outside this class
    //"Readonly  because it cant be changed

    private readonly ProjectOneRepoLayer _repoLayer;
    public  ProjectOneBusinessLayer()
    {
        this._repoLayer = new ProjectOneRepoLayer();
    }

    
    /// <summary>
    /// #1 Login
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns></returns>
    public async Task<LoginDto> LoginAsync(LoginDto loginDto)
    {
        LoginDto list = await this._repoLayer.LoginAsync(loginDto);
        return loginDto;
    }
    /// <summary>
    /// #2 Register a new account
    /// </summary>
    /// <param name="newEmployee"></param>
    /// <returns></returns>
    public async Task<Employee> NewEmployeeAsync(Employee newEmployee)
    {
        Employee employee = await this._repoLayer.NewEmployeeAsync(newEmployee);
        return employee;
    }

    public async Task<List<Ticket>> TicketsAsync(int status)
    {
        List<Ticket> list = await this._repoLayer.TicketsAsync(status);
        return list;
    }

    public async Task<UpdatedTicketDto> UpdateTicketAsync(ApprovalDto approvalDto)  
    {
        if (await this._repoLayer.IsManagerAsync(approvalDto.EmployeeID)) //to see if this employee is a manager, if not its failed
        {
            UpdatedTicketDto approvedTicket = await this._repoLayer.UpdateTicketAsync(approvalDto.TicketID, approvalDto.Status);
            return approvedTicket;
        }
        else return null;
    }

}
