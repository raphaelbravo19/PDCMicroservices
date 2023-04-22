using Microsoft.AspNetCore.Mvc;
using StoresApi.Interfaces;
using StoresApi.Interfaces.Requests;

namespace StoresApi.Controllers;

[ApiController]
[Route("")]
public class StoresController : ControllerBase
{
    private readonly IStoreService _userService;
    private readonly ILogger<StoresController> _logger;

    public StoresController(IStoreService userService, ILogger<StoresController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet(Name = "GetStores")]
    public IActionResult GetStores()
    {
        var response = _userService.GetStores();
        return Ok(response);
    }

    [HttpGet("{userId}", Name = "GetStore")]
    public IActionResult GetStore(int userId)
    {
        var response = _userService.GetStore(userId);
        return Ok(response);
    }

    [HttpPost(Name = "CreateStore")]
    public IActionResult CreateStore(DtoStore dtoStore)
    {
        var response = _userService.CreateStore(dtoStore);
        return Ok(response);
    }
}
