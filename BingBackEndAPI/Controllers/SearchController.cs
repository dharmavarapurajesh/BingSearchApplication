using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly BingSearchService _bingSearchService;

    public SearchController(BingSearchService bingSearchService)
    {
        _bingSearchService = bingSearchService;
    }

    [AllowAnonymous]

    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var result = await _bingSearchService.SearchAsync(query);
        return Ok(result);
    }
}
