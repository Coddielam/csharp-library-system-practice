using Library.Infrastructure;
using Library.Models;

namespace Library.Applications;

public class PatronAppService : IPatronAppService
{
    private LibraryDbContext _dbContext;
    public PatronAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Patron CreatePatron(string name, string address)
    {
        var patron = new Patron(
            id: Guid.NewGuid(),
            name,
            address,
            borrowings: new List<Borrowing>()
        );

        _dbContext.Patrons.Add(patron);

        return patron;
    }
}