using Microsoft.AspNetCore.Mvc;
using webApi.Services;
using webApi.DataClasses.Entities;
using webApi.DataClasses.Validators;
using FluentValidation.Results;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BooksController : ControllerBase
{
    private BooksService _service;
    private BookClValidator _clValidator;
    private BookValidator _validator;

    public BooksController(BooksService service, BookClValidator clValidator, BookValidator validator)
    {
        _service = service;
        _clValidator = clValidator;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookCl bookCl)
    {
        ValidationResult validResult = _clValidator.Validate(bookCl);
        if (validResult.IsValid)
        {
            var result = await _service.AddBook(bookCl);
            return Ok(result);
        }
        else
        {
            return BadRequest(validResult.ToString(" | "));
        }
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
    public async Task<IActionResult> DeleteBooksByWriter(int id)
    {
        var result = await _service.DeleteBooksByWriter(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        ValidationResult validResult = _validator.Validate(book);
        if (validResult.IsValid)
        {
            bool result = await _service.UpdateBook(book);
            return Ok(result);
        }
        else
        {
            return BadRequest(validResult.ToString(" | "));
        }
    }
}
