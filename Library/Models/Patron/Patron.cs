namespace Library.Models;

public class Patron
{
    public string Name { get; }
    public string Address { get; }
    public List<Borrowing> BorrowingHistory { get; }
    public Patron(string name, string address, List<Borrowing> borrowingHistory)
    {
        Name = name;
        Address = address;
        BorrowingHistory = borrowingHistory;
    }
}