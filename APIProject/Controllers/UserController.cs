using Core.Interfaces;
using Core.Entities;
using Core.DtoS;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUser userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await userService.GetById(id);
        if(user == null)
            return BadRequest($"User not found with this id{id}");
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromQuery] User user)
    {
        if (await userService.UserExists(user.UserId))
        {
            return BadRequest("User already exists");
        }

        await userService.AddUser(user);
        return Ok(await userService.GetAll());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var res = await userService.GetById(id);
        if(res == null)
            return BadRequest($"User not found with this id{id}");
        await userService.DeleteUser(res);
        return Ok($"User {res.UserId} deleted");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserDto model)
    {
        var user = await userService.GetById(id);
        if (user == null)
            return BadRequest($"User not found with this id{id}");
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.PhoneNumber = model.PhoneNumber;
        await userService.UpdateUser(user);
        return Ok($"User {user.UserId} updated");
        
    }
    
}