using LibraryManagementSystem.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult UserCreateNew([FromBody] UserCreateModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(UserCreateNew), newUser);
        }
    }
}
