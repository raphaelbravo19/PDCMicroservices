using Microsoft.AspNetCore.Mvc;
using UsersApi.Interfaces;
using UsersApi.Interfaces.Requests;

namespace UsersApi.Controllers;

[ApiController]
[Route("")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet(Name = "GetUsers")]
    public IActionResult GetUsers()
    {
        var response = _userService.GetUsers();
        return Ok(response);
    }

    [HttpGet("{userId}", Name = "GetUser")]
    public IActionResult GetUser(int userId)
    {
        var response = _userService.GetUser(userId);
        return Ok(response);
    }

    [HttpPost(Name = "CreateUser")]
    public IActionResult CreateUser(DtoUser dtoUser)
    {
        var response = _userService.CreateUser(dtoUser);
        return Ok(response);
    }
}
