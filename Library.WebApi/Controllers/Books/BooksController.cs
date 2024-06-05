using Library.Applications;
using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookAppService _bookAppService;

    public BooksController(IBookAppService bookAppService)
    {
        _bookAppService = bookAppService;
    }

    [HttpPost]
    public IActionResult CreateBook(CreateBookRequest request)
    {
        var book = new Book(
            Guid.NewGuid(),
            request.Title,
            request.Author,
            request.ISBN,
            Status.Available
        );

        _bookAppService.CreateBook(book);

        var bookResponse = new CreateBookResponse(
            book.Id,
            book.Title,
            book.Author,
            book.ISBN,
            book.Status
        );

        return Ok(bookResponse);
    }
}