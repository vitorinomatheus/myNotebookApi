using Microsoft.AspNetCore.Mvc;
using Domain.Dtos.UserConnectionDtos;
using Domain.Interfaces.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/userconnection")]
public class UserConnectionController : ControllerBase
{
    private IUserConnectionService _userConnectionService;

    public UserConnectionController(IUserConnectionService userConnectionService)
    {
        _userConnectionService = userConnectionService;
    }

    [HttpPost]
    public async Task<IActionResult> RequestConnection([FromBody] RequestUserConnectionDto requestUserConnectionDto)
    {
        try
        {
            return Ok(await _userConnectionService.RequestUserConnection(requestUserConnectionDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserConnectionDto deleteUserConnectionDto)
    {
        try
        {
            return Ok(await _userConnectionService.Delete<DeleteUserConnectionDto, DeletedUserConnectionDto>(deleteUserConnectionDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("{Id}")]
    public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateUserConnectionDto updateUserConnectionDto)
    {
        updateUserConnectionDto.Id = Id;

        try
        {
            return Ok(await _userConnectionService.Update<UpdateUserConnectionDto, UpdatedUserConnectionDto>(updateUserConnectionDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
}
