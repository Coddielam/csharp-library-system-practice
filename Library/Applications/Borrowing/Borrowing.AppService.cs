using Library.Infrastructure;
using Library.Models;

namespace Library.Applications;

public class BorrowingAppService : IBorrowingAppService
{
    private LibraryDbContext _dbContext;
    public BorrowingAppService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Borrowing CreateBorrowingHistory(Patron patron, List<Book> books)
    {

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