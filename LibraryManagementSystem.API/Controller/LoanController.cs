using LibraryManagementSystem.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/loan")]
    public class LoanController : ControllerBase
    {
        [HttpGet]
        public IActionResult LoanGetAll()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult LoanGetById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult LoanGetByUserId(int userId)
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult LoanCreate([FromBody] LoanModel newLoan)
        {
            if (newLoan == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(LoanCreate), newLoan);
        }

        [HttpPost]
        public IActionResult LoanUpdate([FromBody] LoanModel updateLoan)
        {
            if(updateLoan == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(LoanCreate), updateLoan);
        }

        [HttpDelete("{id}")]
        public IActionResult LoanEnd(int id)
        {
            //Look for loan 
            //If it exists go ahead and end it 
            // otherwise return to different page

            return NoContent();
        }
    }
}
