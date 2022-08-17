using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public Guid TicketID { get; set; }
        public Guid FK_EmployeeID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
    }
}
