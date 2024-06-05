namespace Library.Models;

public class Borrowing
{
    public string PatronId { get; }
    public string BookId { get; }
    public DateTime BorrowedDateTime { get; }
    public DateTime DueDateTime { get; }

    public Borrowing(string patronId, string bookId, DateTime borrowedDateTime, DateTime dueDateTime)
    {
        BookId = bookId;
        PatronId = patronId;
        BorrowedDateTime = borrowedDateTime;
        DueDateTime = dueDateTime;
    }
}