using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace ProjectOneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReimbursementController : ControllerBase
    {
        /// <summary>
        /// Get all the pending request
        /// </summary>
        /// <returns></returns>
        [HttpGet("Tickets/{type}")]
        public async ActionResult<List<Ticket>> PendingTickets(string type)
        {
            if (type.Equals("pending"))
            {
                List<Ticket>tickets();
            }
        }

    }
}
