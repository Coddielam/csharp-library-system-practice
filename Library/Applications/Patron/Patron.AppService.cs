using Library.Infrastructure;
using Library.Models;

namespace Library.Applications;

public class PatronAppService : IPatronAppService
{
    private readonly LibraryDbContext _dbContext;
    public PatronAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Patron CreatePatron(Patron patron)
    {

        _dbContext.Patrons.Add(patron);

        return patron;
    }

    public Patron? GetPatron(Guid id)
    {
        return _dbContext.Patrons.Find(id);
    }
}