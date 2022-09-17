using EFAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        BatchContext _context;
        public AssociateController(BatchContext batchContext)
        {
            _context = batchContext;
        }
    //     private static List<Associate> Associates = new List<Associate>// by using 'static' all associates will use this list
    //    {
    //        new Associate
    //        {
    //            Id = 1, //when we list we use ,
    //            LastName = "Bayaraa",
    //            FirstMidName = "Sam",
    //            DOB = DateTime.Now,

    //        }
    //    };

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Associate>>> GetAll()
        {
            // var dbList = await _context.Associates.ToListAsync();
            // var associateList = new List<Associate>();

            // foreach (var item in dbList)
            // {
            //     associateList.Add(new Associate{
            //         Id = item.Id,
            //         FirstMidName = item.FirstMidName,
            //         DOB = item.DOB,
            //     });
            // }
            // return Ok(Associates);

            return Ok(await _context.Associates.ToListAsync());
            //return Ok(AssociateList);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Associate>>> GetOne(int id)
        {
            // Associate blank = new Associate
            // {
            //     Id = 0,
            //     LastName = "",
            //     FirstMidName = "",
            //     DOB = DateTime.Now,
            // };

            //var associate = Associates.Find(a => a.Id == id);
            var associate = await _context.Associates.FindAsync(id); //instead of telling it go through th whole list
            if (associate == null)
                return BadRequest("Associate not found");
           // return Ok(associate);
           return Ok(await _context.Associates.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Associate>>> AddAssociate(Associate newAssociate) //putting data in database
        {
            // Associates.Add(newAssociate);
            // return Ok(Associates);

            _context.Associates.Add(newAssociate);
            await _context.SaveChangesAsync();

            //return Ok(Associates);

            return Ok(await _context.Associates.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Associate>>> UpdateAssiciate(Associate update) //chaning/editing
        {
            //var assoicate = Associates.Find(a => a.Id == update.Id);

            var assoicate = await _context.Associates.FindAsync(update.Id);

            if (assoicate == null)
            return BadRequest("Associate not found");

                assoicate.FirstMidName = update.FirstMidName;
                assoicate.LastName = update.LastName;
                assoicate.DOB = update.DOB;

                await _context.SaveChangesAsync(); //added

            //return Ok(Associates);

            return Ok (await _context.Associates.ToListAsync());

        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<List<Associate>>> DeleteAssociate(int id)
        {
            // var associate = Associates.Find(a => a.Id == id);
             var associate = await _context.Associates.FindAsync(id);

            if (associate == null)
                return BadRequest("Associate not found");
            
            //Associates.Remove(associate);
            _context.Associates.Remove(associate);
           // return Ok(Associates);
           return Ok (await _context.Associates.ToListAsync());
        }
    }
}
