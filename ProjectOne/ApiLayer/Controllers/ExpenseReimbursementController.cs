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
        private readonly ProjectOneBusinessLayer _businessLayer; // "_businessLayer" naming convention for private local variables. 
                                                                 // this is a business layer Entity, the instance of the Business layer. Using this to call the method
                                                                 //It is using "Private" because it is protecting from calling it from outside this class
                                                                 //"Readonly  because it cant be changed
        public ExpenseReimbursementController()
        {
            this._businessLayer = new ProjectOneBusinessLayer();
        }

        /// <summary>
        /// Get all the pending request
        /// </summary>
        /// <returns></returns>


        [HttpGet("TicketsAsync")] //get all rtickets   
        [HttpGet("TicketsAsync/{status}")] //get all of a type request
        //.[HttpGet("TicketsAsync/{id?}/{status?}")] //FIGURE OUT HOW TO STRUCTURE THE QUERY SO THAT OTHE OPTIONAL VALUES ARE INDEED OPTIONAL
        //[HttpGet("TicketsAsync/{id}")]
        public async Task<ActionResult<List<Ticket>>> TicketsAsync(int status, Guid? id)
        {
            List<Ticket> ticketList = await this._businessLayer.TicketsAsync(status); //its in the bussiness Layer, because BusinessLayer deals with all the logics. Due to seperation concern, leave minimum logic as possible
            return Ok(ticketList); //returns 200
            //return null;
            //0=pending, 1=Aprroved, 2=Denied

        }
        [HttpGet("LoginAsync")]
        public async Task<ActionResult<List<LoginDto>>> LoginAsync(string firstName, string lastName, string userName, string password)
        {
            List<LoginDto> loginInfo = await this._businessLayer.LoginAsync(firstName, lastName);
            return Ok(loginInfo);
        }

        [HttpPut("UpdateTicketAsync")]
        public async Task<ActionResult<UpdatedTicketDto>> TicketStatusAsync(ApprovalDto approval) //it waa called Jimmy on Marks demo because "TicketStatus" can be called anything, but keep it consistant
        {
            if (ModelState.IsValid) //system will try to match if data is valid, if its not valid it will throw exception. If its valid it will etirate.
            {
                UpdatedTicketDto approvedTicket = await this._businessLayer.UpdateTicketAsync(approval);
                //send the ApprovalDto to the business layer
                return Ok(approvedTicket);
            }
            else return Conflict(approval);    //StatusCode(StatusCodes.Status409Conflict); 
        }

    }
}
