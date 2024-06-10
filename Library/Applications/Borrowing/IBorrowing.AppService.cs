using Library.Models;

namespace Library.Applications;

public interface IBorrowingAppService
{
    Borrowing CreateBorrowingHistory(Patron patron, List<Book> books);
}