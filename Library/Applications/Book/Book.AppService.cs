using Library.Infrastructure;
using Library.Models;

namespace Library.Applications;

public class BookAppService : IBookAppService
{
    private readonly LibraryDbContext _dbContext;

    public BookAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Book> GetBooks(List<Guid> ids)
    {
        return _dbContext.Books.Where(b => ids.Contains(b.Id)).ToList();
    }

    public Book CreateBook(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
        return book;
    }
}