using LibraryManagementSystem.API.Models;
using LibraryManagementSystem.Application.Services.Interfaces;
using LibraryManagementSystem.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controller
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult UserCreateNew([FromBody] UserCreateNewModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }

            var id = _userService.UserCreateNew(newUser);

            return CreatedAtAction(nameof(UserCreateNew), id, newUser);
        }

        [HttpGet]
        public IActionResult UserGetAll(string query)
        {
            var users = _userService.UserGetAll(query);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult UserGetById(int id)
        {
            var user = _userService.UserGetById(id);

            return Ok(user);
        }
    }
}
