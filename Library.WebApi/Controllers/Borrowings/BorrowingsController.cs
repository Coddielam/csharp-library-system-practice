using Library.Applications;
using Library.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[ApiController]
[Route("borrowings")]
public class BorrowingsController : ControllerBase
{
    private readonly IBookAppService _bookAppService;
    private readonly IBorrowingAppService _borrowingAppService;
    private readonly IPatronAppService _patronAppService;

    public BorrowingsController(
        IBookAppService bookAppService,
        IBorrowingAppService borrowingAppService,
        IPatronAppService patronAppService
    )
    {
        _bookAppService = bookAppService;
        _borrowingAppService = borrowingAppService;
        _patronAppService = patronAppService;
    }

    [HttpPost]
    public IActionResult CreateBorrowingHistory(CreateBorrowingBooksRequest request)
    {
        var books = _bookAppService.GetBooks(request.BookIds);

        if (books.Count != request.BookIds.Count)
        {
            var unknownIds = books.Select(book => !request.BookIds.Contains(book.Id));
            return BadRequest(string.Format("Book ids not found: {0}", string.Join(", ", unknownIds)));
        }

        var patron = _patronAppService.GetPatron(request.PatronId);

        if (patron == null)
        {
            return BadRequest(string.Format("Patron id not found: {0}", request.PatronId));
        }

        var borrowing = _borrowingAppService.CreateBorrowingHistory(patron, books);

        return Ok(borrowing);
    }
}