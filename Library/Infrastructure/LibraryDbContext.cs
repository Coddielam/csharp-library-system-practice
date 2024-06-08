using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    { }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Patron> Patrons { get; set; } = null!;
    public DbSet<Borrowing> Borrowings { get; set; } = null!;
}