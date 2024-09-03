using Models;

namespace Repository.BookRepository;

public interface IBookRepository
{
    public Task<BookModel> AddBook(BookModel book);
}