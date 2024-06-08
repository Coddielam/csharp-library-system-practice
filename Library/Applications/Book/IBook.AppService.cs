using Library.Models;

namespace Library.Applications;

public interface IBookAppService
{
    Book CreateBook(string title, string author, string isbn);
    Book? LendBook(Guid id);
    void ReturnBook(Guid id);
}