using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.DataClasses.Entities;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WritersController : ControllerBase
{
    private WritersService _service;

    public WritersController(WritersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddWriter(WriterCl writerCl)
    {
        var result = await _service.AddWriter(writerCl);

        return Ok(result);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteWriter(int id)
    {
        var result = await _service.DeleteWriter(id);
        return Ok(result);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetWriterById(int id)
    {
        var result = await _service.GetWriters(id);
        return Ok(result);
    }

    [HttpGet("{name:minlength(1)}")]
    public IActionResult GetWritersByName(string name)
    {
        Writer[] result = _service.GetWriters(name);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateWriter(Writer writer)
    {
        bool result = await _service.UpdateWriter(writer);
        return Ok(result);
    }
}
