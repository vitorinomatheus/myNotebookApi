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
            return Ok(await _userService.FilteredList<ListUserDto, ListedUserDto>(listUserDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] CreateUserDto createUserDto)
    {
        try
        {
            return Ok(await _userService.Insert<CreateUserDto, CreatedUserDto>(createUserDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserDto deleteUserDto)
    {
        try
        {
            return Ok(await _userService.Delete<DeleteUserDto, DeletedUserDto>(deleteUserDto)); 
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }

    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateUserDto updateUserDto)
    {
        updateUserDto.Id = Id;
        try
        {
            return Ok(await _userService.Update<UpdateUserDto, UpdatedUserDto>(updateUserDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
            throw;
        }
    }
}
