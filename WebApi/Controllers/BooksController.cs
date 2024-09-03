using Dto.Book;
using Microsoft.AspNetCore.Mvc;
using Service.Book;

namespace WebApi.Controllers;

[ApiController]
[Route("books")]
public class BooksController: ControllerBase
{
    private readonly IBookService _bookService;
    public BooksController(
        IBookService bookService
    )
    {
        _bookService = bookService;
    }

    [HttpPost]
    public ActionResult<BookDto> CreateBook(BookDto bookDto)
    {
        var dto = _bookService.CreateBook(bookDto);
        return Ok(dto);
    }
}