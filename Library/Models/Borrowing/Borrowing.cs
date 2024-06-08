namespace Library.Models;

public class Borrowing
{
    public Guid Id { get; private set; }
    public Patron Patron { get; private set; } = null!;
    public Guid PatronId { get; private set; }
    public ICollection<Book> Books { get; private set; } = null!;
    public DateTime BorrowedDateTime { get; private set; }
    public DateTime DueDateTime { get; private set; }

    public Borrowing() { }

    public Borrowing(Guid id, Patron patron, ICollection<Book> books, DateTime borrowedDateTime, DateTime dueDateTime)
    {
        Id = id;
        Books = books;
        Patron = patron;
        PatronId = patron.Id;
        BorrowedDateTime = borrowedDateTime;
        DueDateTime = dueDateTime;
    }
}