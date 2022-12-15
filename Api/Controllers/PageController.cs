using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
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

}
