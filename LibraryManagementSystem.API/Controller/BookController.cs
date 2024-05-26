using LibraryManagementSystem.API.Models;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
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
        public IActionResult BookCreateNew([FromBody] BookCreateNewModel newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            var id = _bookService.BookCreateNew(newBook);

            return CreatedAtAction(nameof(BookGetById), new { id }, newBook);
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
