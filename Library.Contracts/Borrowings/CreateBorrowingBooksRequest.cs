namespace Library.Contracts;

public record CreateBorrowingBooksRequest
(
    Guid PatronId,
    List<Guid> BookIds
);