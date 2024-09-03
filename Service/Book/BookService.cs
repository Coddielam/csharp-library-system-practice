using Dto.Book;
using Repository.BookRepository;

namespace Service.Book;

public class BookService : IBookService
{
    private IBookRepository _bookRepository;
    public BookService(
        IBookRepository bookRepository
    )
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDto> CreateBook(BookDto book)
    {
        var bookModel = await _bookRepository.AddBook(
            new Models.BookModel
            {  
                Name = book.Name 
            }
        );

        return new BookDto
        {
            Id = bookModel.Id,
            Name = bookModel.Id,
        };
    }
}
