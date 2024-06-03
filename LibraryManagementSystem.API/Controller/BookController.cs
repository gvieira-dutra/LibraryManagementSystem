using LibraryManagementSystem.API.Models;
using LibraryManagementSystem.Application.Commands.BookCreateNew;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMediator _mediator;
        public BookController(IBookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }

        // api/bookgetall/query?query string
        [HttpGet]
        public IActionResult BookGetAll (string query)
        {
            var books = _bookService.BookGetAll(query);

            return Ok(books);
        }

        // api/books/id
        [HttpGet("{id}")]
        public IActionResult BookGetById(int id)
        {
            var book = _bookService.BookGetOne(id);

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
        public IActionResult BookDelete(int id)
        {
            _bookService.BookDelete(id);

            return NoContent();

        }

    }
}
