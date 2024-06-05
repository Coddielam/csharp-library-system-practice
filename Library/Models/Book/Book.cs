namespace Library.Models;

public class Book
{
    public Guid Id { get; }
    public string Title { get; }
    public string Author { get; }
    public string ISBN { get; }
    public Status Status { get; set; }

    public Book(Guid id, string title, string author, string isbn, Status status)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        Status = status;
    }
}

public enum Status
{
    Available = 0,
    Unavailable = 1,
}