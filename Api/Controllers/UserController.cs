using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;

namespace Api.Controllers;

[ApiController]
[Route(template:"api/user")]
public class UserController : ControllerBase
{

    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetUserDto getUserDto)
    {
        try
        {
            var foundUser = await _userService.GetById(getUserDto);
            return Ok(foundUser);
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
            // TODO: Tratamento de erros de requisição;
        }
    }
}
