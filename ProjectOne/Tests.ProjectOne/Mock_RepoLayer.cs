using Models;
using ModelsLayer;
using RepoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ProjectOne
{
    public class Mock_RepoLayer : IProjectOneRepoLayer
    {
        public Task<bool> IsManagerAsync(Guid employeeID)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> LoginAsync(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> NewEmployeeAsync(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> NewTicketAsync(Ticket newTicket)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> TicketsAsync(int status)
        {
            throw new NotImplementedException();
        }

    /// <summary>
    /// creates a fake UpdatedTicketDto and returns it
    /// </summary>
    /// <param name="ticketID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
        public Task<UpdatedTicketDto> UpdateTicketByIDAsync(Guid ticketID)
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedTicketDto> UpdateTicketAsync(Guid ticketID, int status)
        {
            throw new NotImplementedException();
        }

    }
}
