using Library.Models;

namespace Library.Applications;

public interface IBookAppService
{
    List<Book> GetBooks(List<Guid> ids);
    Book CreateBook(Book book);
}