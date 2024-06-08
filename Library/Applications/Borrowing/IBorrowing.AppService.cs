using Library.Models;

namespace Library.Applications;

public interface IBorrowingAppService
{
    Borrowing CreateBorrowingHistory(Guid patronId, List<Guid> bookIds);
}