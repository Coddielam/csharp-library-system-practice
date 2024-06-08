namespace Library.Contracts;

public record CreateBorrowingResponse
(
    Guid PatronId,
    List<Guid> BookIds
);