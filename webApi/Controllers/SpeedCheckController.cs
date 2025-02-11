using Microsoft.AspNetCore.Mvc;
using webApi.Services;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SpeedCheckController : Controller
{
    private readonly ISpeedCheckService _service;

    public SpeedCheckController(ISpeedCheckService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> FillDatabase(int count)
    {
        return Ok(await _service.FillDatabase(count));
    }

    [HttpGet]
    public async Task<IActionResult> GetEntities(int startIndex, int count)
    {
        return Ok(await _service.GetAsync(startIndex, count));
    }

    [HttpGet]
    public async Task<IActionResult> NotCompiledExcecutionTimeTest()
    {
        return Ok(await _service.ExcecutionTimeTest(false));
    }

    [HttpGet]
    public async Task<IActionResult> CompiledExcecutionTimeTest()
    {
        return Ok(await _service.ExcecutionTimeTest(true));
    }
}