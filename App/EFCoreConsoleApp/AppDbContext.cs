using App;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsoleApp;

public class AppDbContext: DbContext
{
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=products.db");
    }
}