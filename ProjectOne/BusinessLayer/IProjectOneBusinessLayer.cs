using Models;
using ModelsLayer;

namespace BusinessLayer
{
    public interface IProjectOneBusinessLayer
    {
        Task<LoginDto> LoginAsync(LoginDto loginDto);
        Task<Employee> NewEmployeeAsync(Employee newEmployee);
        Task<Ticket> NewTicketAsync(Ticket newTicket);
        Task<List<Ticket>> TicketsAsync(int status);
        Task<UpdatedTicketDto> UpdateTicketAsync(ApprovalDto approvalDto);
    }
}