using Data.AppDbContext;
using Models;

namespace Repository.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _appDbContext;
    public BookRepository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    async public Task<BookModel> AddBook(BookModel book)
    {
        await _appDbContext.Books.AddAsync(book);
        return book;
    }
}