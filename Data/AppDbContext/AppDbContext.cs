using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.AppDbContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookModel> Books { get; set; }
}