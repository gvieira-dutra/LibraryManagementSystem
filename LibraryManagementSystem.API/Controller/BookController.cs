using LibraryManagementSystem.Application.Commands.BookCreateNew;
using LibraryManagementSystem.Application.Commands.BookDelete;
using LibraryManagementSystem.Application.Queries.BookGetOne;
using LibraryManagementSystem.Application.Queries.BookGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/bookgetall/query?query string
        [HttpGet]
        public async Task<IActionResult> BookGetAll (string query)
        {
            var command = new BookGetAllQuery(query);

            var books = await _mediator.Send(command);

            return Ok(books);
        }

        // api/books/id
        [HttpGet("{id}")]
        public async Task<IActionResult> BookGetById(int id)
        {
            var command = new BookGetOneQuery(id);

            var book = await _mediator.Send(command);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> BookCreateNew([FromBody] BookCreateNewCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BookGetById), new { id }, command);
        }

        // api/delete/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> BookDelete(int id)
        {
            var command = new BookDeleteCommand(id);

            await _mediator.Send(command);

            return NoContent();

        }

    }
}
