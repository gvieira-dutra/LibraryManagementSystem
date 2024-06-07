using LibraryManagementSystem.Application.Commands.LoanCreate;
using LibraryManagementSystem.Application.Commands.LoanEnd;
using LibraryManagementSystem.Application.Commands.LoanUpdate;
using LibraryManagementSystem.Application.Queries.LoanGetAll;
using LibraryManagementSystem.Application.Queries.LoanGetById;
using LibraryManagementSystem.Application.Queries.LoanGetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/loan")]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LoanGetAll()
        {
            var command = new LoanGetAllQuery();

            var loans = await _mediator.Send(command);

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult >LoanGetById(int id)
        {
            var command = new LoanGetByIdQuery(id);
            var loan = await _mediator.Send(command);

            return Ok(loan);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> LoanGetByUserId(int id)
        {
            var command = new LoanGetByUserIdQuery(id);

            var loans = await _mediator.Send(command);

            return Ok(loans);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> LoanCreate([FromBody] LoanCreateCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var message = await _mediator.Send(command);

            return Ok(message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> LoanUpdate([FromBody] LoanUpdateCommand command)
        {
            if(command == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(LoanCreate), id, command);
        }

        [HttpDelete("end/{id}")]
        public async Task<IActionResult> LoanEnd(int id)
        {
            var task = new LoanEndCommand(id);

            var message = await _mediator.Send(task);

            return Ok(message);
        }

    }
}
