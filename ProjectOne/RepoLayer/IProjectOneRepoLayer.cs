using Models;
using ModelsLayer;

namespace RepoLayer
{
    public interface IProjectOneRepoLayer
    {
        Task<bool> IsManagerAsync(Guid employeeID);
        Task<LoginDto> LoginAsync(LoginDto login);
        Task<Employee> NewEmployeeAsync(Employee newEmployee);
        Task<Ticket> NewTicketAsync(Ticket newTicket);
        Task<List<Ticket>> TicketsAsync(int status);
        Task<UpdatedTicketDto> UpdateTicketAsync(Guid ticketID, int status);
    }
}