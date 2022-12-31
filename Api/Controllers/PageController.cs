using Microsoft.AspNetCore.Mvc;
using Domain.Dtos.PageDtos;
using Domain.Interfaces.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/page")]
public class PageController : ControllerBase
{
    private IPageService _pageService;

    public PageController(IPageService pageService)
    {
        _pageService = pageService;
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] CreatePageDto createPageDto)
    {
        try
        {
            return Ok(await _pageService.Insert<CreatePageDto, CreatedPageDto>(createPageDto));
        }
        catch (System.Exception)
        {            
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeletePageDto deletePageDto)
    {
        try
        {
            return Ok(await _pageService.Delete<DeletePageDto, DeletedPageDto>(deletePageDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("notebook/{NotebookId}")]
    public async Task<IActionResult> ListPagesFromNotebook([FromRoute] ListPagesFromNotebookDto listPagesFromNotebookDto)
    {
        try
        {
            return Ok(await _pageService.FilteredList<ListPagesFromNotebookDto, ListedPagesFromNotebookDto>(listPagesFromNotebookDto));
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

}
