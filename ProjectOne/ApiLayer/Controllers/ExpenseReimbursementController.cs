using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace ProjectOneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReimbursementController : ControllerBase
    {
        private readonly ProjectOneBusinessLayer _businessLayer;
        public ExpenseReimbursementController()
        {
            this._businessLayer = new ProjectOneBusinessLayer();
        }

        /// <summary>
        /// Get all the pending request
        /// </summary>
        /// <returns></returns>


        [HttpGet("TicketsAsync")]
        [HttpGet("TicketsAsync/{type}")]
        [HttpGet("TicketsAsync/{type}{id}")]
        [HttpGet("TicketsAsync/{id}")]
        public async ActionResult<Task<List<Ticket>>> TicketsAsync(string? type, Guid? id)
        {
            if (type.Equals("Pending"))
            {
                List<Ticket> ticketList = await this._businessLayer.TicketsAsync();
                return ticketList;
            }
            return null;

        }

    }
}
