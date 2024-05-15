using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopListApp.Abstractions;
using ShopListApp.Domain.Models;
using ShopListApp.Domain.Models.Input;
using System.Collections.ObjectModel;

namespace ShopListApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("get-user")]
        public IActionResult GetUserById(int userId)
        {
            var user = _userService.GetUser(userId);

            if (user == null)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("get-users")]
        public IActionResult Getusers()
        {
            var users = _mapper.Map<Collection<UserDTO>>(_userService.GetUsers());

            if (users == null)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpPost("create-user")]
        public IActionResult Createuser([FromBody] UserDTO user)
        {

            if (!_userService.CreateUser(_mapper.Map<User>(user)))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("delete-user")]
        public IActionResult Deleteuser(int userId)
        {

            if (!_userService.DeleteUser(userId))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("update-user")]
        public IActionResult Updateuser([FromQuery] int userId, string newName)
        {
            var user = _userService.GetUser(userId);
            if (!ModelState.IsValid)
                return StatusCode(500, ModelState);

            user.Name = newName;

            if (!_userService.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
