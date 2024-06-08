namespace Library.Models;

public class Patron
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Address { get; private set; } = null!;
    public ICollection<Borrowing> Borrowings { get; private set; } = null!;
    public Patron() { }
    public Patron(Guid id, string name, string address, ICollection<Borrowing> borrowings)
    {
        Id = id;
        Name = name;
        Address = address;
        Borrowings = borrowings;
    }
}