using LibraryManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        // api/bookgetall/query?query string
        [HttpGet]
        public IActionResult BookGetAll (string query)
        {
            return Ok();
        }

        // api/books/id
        [HttpGet("{id}")]
        public IActionResult BookGetById(int id) 
        {
            //get book by id
            return Ok();
        }

        [HttpPost]
        public IActionResult BookCreateNew([FromBody] BookCreateModel newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(BookGetById), new {id = newBook.Id}, newBook);
        }

        // api/delete/1
        [HttpDelete("{id}")]
        public IActionResult BookDelete(int id)
        {
            //Look for book to delete
            //If it exists go ahead with deleting it 
            // otherwise return to different page

            return NoContent();

        }

    }
}
