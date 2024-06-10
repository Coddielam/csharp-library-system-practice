using Library.Models;

namespace Library.Applications;

public interface IPatronAppService
{
    Patron CreatePatron(Patron patron);
    Patron? GetPatron(Guid id);
}