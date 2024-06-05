using Library.Models;

namespace Library.Contracts;

public record CreateBookRequest
(
    string Title,
    string Author,
    string ISBN
);