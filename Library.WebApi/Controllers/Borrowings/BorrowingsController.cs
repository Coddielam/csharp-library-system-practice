using Library.Applications;
using Library.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[ApiController]
[Route("borrowings")]
public class BorrowingsController : ControllerBase
{
    private IBorrowingAppService _borrowingAppService;
    public BorrowingsController(IBorrowingAppService borrowingAppService)
    {
        _borrowingAppService = borrowingAppService;
    }

    [HttpPost]
    public IActionResult CreateBorrowingHistory(CreateBorrowingBooksRequest request)
    {
        var borrowing = _borrowingAppService.CreateBorrowingHistory(request.PatronId, request.BookIds);
        return Ok(borrowing);
    }
}