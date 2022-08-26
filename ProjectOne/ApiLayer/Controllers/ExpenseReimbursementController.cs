using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        /// # 1 Login: must be able to login by using username and password 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<List<LoginDto>>> LoginAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                LoginDto loginDto = await this._businessLayer.LoginAsync(login);
                return Ok(loginDto);
            }
            else return Conflict(login);
        }
        /// <summary>
        /// #2 New Account registration (Must ensure the username is not already registered & Default employee role)
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        [HttpPost("Register a New Account")]
        public async Task<ActionResult<List<Employee>>> NewEmployeeAsync(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await this._businessLayer.NewEmployeeAsync(newEmployee);
                return Ok(employee);
            }
            else return Conflict(newEmployee);
        }


       /// <summary>
       /// #3 Submit a New Ticket
       /// </summary>
       /// <param name="newTicket"></param>
       /// <returns></returns>       
       [HttpPut("Submitting tickets")]
       public async Task<ActionResult<List<Ticket>>> NewTicketAsync(Ticket newTicket)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = await this._businessLayer.NewTicketAsync(newTicket);
                return Ok(ticket);
            }
            else return Conflict(newTicket);
        }
        
         /// <summary>
         /// #4 Updating Status
         /// </summary>
         /// <param name="approval"></param>
         /// <returns></returns>         
        [HttpPut("Updating Status as a manager")]
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


        /// <summary>
        /// #5 See tickets by status   
        /// </summary>
        /// <param name="status"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Tickets")] //get all of a type request
        public async Task<ActionResult<List<Ticket>>> TicketsAsync(int status, Guid? id)
        {
            List<Ticket> ticketList = await this._businessLayer.TicketsAsync(status); //its in the bussiness Layer, because BusinessLayer deals with all the logics. Due to seperation concern, leave minimum logic as possible
            return Ok(ticketList); //returns 200
            //return null;
            //0=pending, 1=Aprroved, 2=Denied

        }


    }
}
