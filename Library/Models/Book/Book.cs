namespace Library.Models;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Isbn { get; private set; }
    public Status Status { get; set; }

    public Book(Guid id, string title, string author, string isbn, Status status)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Status = status;
    }
}

public enum Status
{
    Available = 0,
    Unavailable = 1,
}