using Library.Infrastructure;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Applications;

public class BookAppService : IBookAppService
{
    private readonly Dictionary<Guid, Book> _booksDict = new();

    private readonly LibraryDbContext _dbContext;

    public BookAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateBook(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }

    public Book? LendBook(Guid id)
    {
        var book = _dbContext.Books.Find(id);
        if (book != null)
        {
            UpdateBookStatus(id, Status.Unavailable);
            return book;
        }
        return null;
    }

    public void ReturnBook(Guid id)
    {
        // TODO: handles book not found
        UpdateBookStatus(id, Status.Available);
    }

    private void UpdateBookStatus(Guid id, Status status)
    {
        var book = _dbContext.Books.Find(id);
        if (book != null)
        {
            book.Status = status;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}