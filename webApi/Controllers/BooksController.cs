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
}