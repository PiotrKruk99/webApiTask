using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.DataClasses.Entities;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BooksController : ControllerBase
{
    private BooksService _service;

    public BooksController(BooksService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookCl bookCl)
    {
        var result = await _service.AddBook(bookCl);

        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        Book[] result = _service.GetBooks();
        return Ok(result);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _service.DeleteBook(id);
        return Ok(result);
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteBookByWriter(int id)
    {
        var result = await _service.DeleteBooksByWriter(id);
        return Ok(result);
    }
}
