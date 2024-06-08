using Library.Applications;
using Library.Contracts;
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

        var book = _bookAppService.CreateBook(request.Title, request.Author, request.Isbn);

        var bookResponse = new CreateBookResponse(
            book.Id,
            book.Title,
            book.Author,
            book.Isbn,
            book.Status
        );

        return Ok(bookResponse);
    }
}