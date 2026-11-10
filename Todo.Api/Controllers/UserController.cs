using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using Todo.Application.DTOs.Request;

namespace Todo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController:Controller
{
    
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
        
    }

    [HttpPost]
    public async  Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {

       var result= await _userService.CreateUserAsync(createUserDto);
        
      if(!result)
          return BadRequest("Failed to create user");
       
       
       
       return Created();
    }
    
    
}