using Library.Models;

namespace Library.Contracts;

public record CreatePatronResponse
(
    Guid Id,
    string Name,
    string Address,
    List<Borrowing> Borrowings
);