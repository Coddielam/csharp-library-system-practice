using Dto.Book;

namespace Service.Book;


public interface IBookService
{
    public Task<BookDto> CreateBook(BookDto book);
}