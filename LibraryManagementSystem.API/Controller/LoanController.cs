using LibraryManagementSystem.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/loan")]
    public class LoanController : ControllerBase
    {
        [HttpPost]
        public IActionResult LoanCreate([FromBody] LoanModel newLoan)
        {
            if (newLoan == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(LoanCreate), newLoan);
        }
    }
}
