
using Library.Infrastructure;
using Library.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Library.Applications;

public class BorrowingAppService : IBorrowingAppService
{
    private LibraryDbContext _dbContext;
    public BorrowingAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Borrowing CreateBorrowingHistory(Guid patronId, List<Guid> bookIds)
    {
        var books = _dbContext.Books
            .Where(b => bookIds.Contains(b.Id))
            .ToList();

        if (bookIds.Count != books.Count)
        {
            // TODO: handle unable to lend all books
            throw new Exception("Books not found");
        }

        var patron = _dbContext.Patrons.Find(patronId);
        if (patron == null)
        {
            // TODO: handle unfound patron
            throw new Exception("Patron not found");
        }

        var borrowing = new Borrowing(
            id: Guid.NewGuid(),
            patron,
            books,
            borrowedDateTime: DateTime.Now,
            dueDateTime: DateTime.Now.AddDays(14)
        );

        _dbContext.Borrowings.Add(borrowing);
        _dbContext.SaveChanges();

        return borrowing;
    }
}