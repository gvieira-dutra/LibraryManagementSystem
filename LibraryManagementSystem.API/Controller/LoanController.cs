using LibraryManagementSystem.API.Models;
using LibraryManagementSystem.Application.Services.Implementation;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/loan")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public IActionResult LoanGetAll()
        {
            var loans = _loanService.LoanGetAll();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public IActionResult LoanGetById(int id)
        {
            var loan = _loanService.LoanGetById(id);

            return Ok(loan);
        }

        [HttpGet("user/{id}")]
        public IActionResult LoanGetByUserId(int id)
        {
            var loans = _loanService.LoanGetByUserId(id);

            return Ok(loans);
        }
        
        [HttpPost("create")]
        public IActionResult LoanCreate([FromBody] LoanCreateModel newLoan)
        {
            if (newLoan == null)
            {
                return BadRequest();
            }

            var id = _loanService.LoanCreate(newLoan);

            return CreatedAtAction(nameof(LoanCreate), id, newLoan);
        }
        [HttpPost("end/{id}")]
        public IActionResult LoanEnd(int id)
        {
            var message = _loanService.LoanEnd(id);

            return Ok(message);
        }

        [HttpPost("update")]
        public IActionResult LoanUpdate([FromBody] LoanUpdateModel updateLoan)
        {
            if(updateLoan == null)
            {
                return BadRequest();
            }

            var id = _loanService.LoanUpdate(updateLoan);

            return CreatedAtAction(nameof(LoanCreate), id, updateLoan);
        }

    }
}
