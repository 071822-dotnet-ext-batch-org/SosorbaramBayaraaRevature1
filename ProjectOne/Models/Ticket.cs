using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Ticket
    {
        public Ticket(Guid ticketID, Guid fK_EmployeeID, string description, double amount, int status)
        {
            TicketID = ticketID;
            FK_EmployeeID = fK_EmployeeID;
            Description = description;
            Amount = amount;
            Status = status;
        }

        public Guid TicketID { get; set; }
        public Guid FK_EmployeeID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
    }
}
