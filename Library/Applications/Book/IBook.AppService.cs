using Library.Models;

namespace Library.Applications;

public interface IBookAppService
{
    List<Book> GetBooks(List<Guid> ids);
    Book CreateBook(Book book);
    Book? LendBook(Guid id);
    void ReturnBook(Guid id);
}