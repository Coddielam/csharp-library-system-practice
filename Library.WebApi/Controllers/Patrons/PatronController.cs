using Library.Applications;
using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[ApiController]
[Route("patrons")]
public class PatronsController : ControllerBase
{
    private readonly IPatronAppService _patronAppService;
    public PatronsController(IPatronAppService patronAppService)
    {
        _patronAppService = patronAppService;
    }

    [HttpPost]
    public IActionResult CreatePatron(CreatePatronRequest request)
    {
        var patron = _patronAppService.CreatePatron(request.Name, request.Address);
        var patronResponse = new CreatePatronResponse(
            patron.Id,
            patron.Name,
            patron.Address,
            patron.Borrowings.ToList()
        );
        return Ok(patronResponse);
    }
}