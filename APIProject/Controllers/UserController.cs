using APIProject.Interfaces;
using Core.Entities;
using  APIProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUser  _userService;

    public UserController(IUser userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await _userService.GetById(id);
        if(user == null)
            return BadRequest($"User not found with this id{id}");
        return user;
    }

    
}