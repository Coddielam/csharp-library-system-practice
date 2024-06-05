using Library.Models;

namespace Library.Contracts;

public record CreateBookResponse
(
    Guid Id,
    string Title,
    string Author,
    string ISBN,
    Status Status
);