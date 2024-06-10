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
        var patron = new Patron(
            id: Guid.NewGuid(),
            name: request.Name,
            address: request.Address,
            borrowings: new List<Borrowing>()
        );

        _patronAppService.CreatePatron(patron);

        var patronResponse = new CreatePatronResponse(
            patron.Id,
            patron.Name,
            patron.Address,
            patron.Borrowings.ToList()
        );
        return Ok(patronResponse);
    }

    [HttpGet("{id}")]
    public IActionResult GetPatrons(Guid id)
    {
        var patron = _patronAppService.GetPatron(id);
        if (patron == null)
        {
            return NotFound(string.Format("Patrong with id - {0} not found", id));
        }
        return Ok(_patronAppService.GetPatron(id));
    }
}