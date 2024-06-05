using Library.Models;

namespace Library.Applications;

public interface IBookAppService
{
    void CreateBook(Book book);
    Book? LendBook(Guid id);
    void ReturnBook(Guid id);
}