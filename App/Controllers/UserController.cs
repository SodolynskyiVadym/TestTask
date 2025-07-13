using System.Text.RegularExpressions;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;


[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly Regex _emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpPost("")]
    public IActionResult CreateUser([FromBody] UserModel user)
    {
        if (user.FullName.Length < 2 || user.DateOfBirth > DateTime.Now || _emailRegex.IsMatch(user.Email) == false ||
            _userService.GetUsers().Any(u => u.Email == user.Email))
        {
            return BadRequest("Invalid user data");
        }

        _userService.Add(user);
        return StatusCode(201, "User was created successfully");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        bool result = _userService.Delete(id);
        if (result) return Ok("User was deleted successfully");
        return NotFound("User not found");
    }
}