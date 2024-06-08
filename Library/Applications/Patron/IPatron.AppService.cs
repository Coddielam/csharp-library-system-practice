using Library.Models;

namespace Library.Applications;

public interface IPatronAppService
{
    Patron CreatePatron(string name, string address);
}