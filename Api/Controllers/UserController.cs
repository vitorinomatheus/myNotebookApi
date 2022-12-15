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
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserDto getUserDto)
    {
        try
        {
            return Ok(await _userService.GetById<GetByIdUserDto, FoundUserDto>(getUserDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
            // TODO: Tratamento de erros de requisição;
        }
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ListUserDto listUserDto) 
    {
        try
        {
            return Ok(await _userService.List<ListUserDto, ListedUserDto>(listUserDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }
}
