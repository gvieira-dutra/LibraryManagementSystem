using LibraryManagementSystem.Application.Commands.UserCreateNew;
using LibraryManagementSystem.Application.Queries.UserGetAll;
using LibraryManagementSystem.Application.Queries.UserGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> UserGetAll(string query)
        {
            var command = new UserGetAllQuery(query);

            var users = await _mediator.Send(command);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserGetById(int id)
        {
            var command = new UserGetByIdQuery(id);

            var user = await _mediator.Send(command);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> UserCreateNew([FromBody] UserCreateCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(UserCreateNew), id, command);
        }

    }
}
