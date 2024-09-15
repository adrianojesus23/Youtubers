using App.ConcurrencyAsynchrony;
using Microsoft.EntityFrameworkCore;
using Client = App.Client;

namespace EFCoreConsoleApp;

public class AppDbContext: DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Material> Materials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:/Youtubers/Youtubers/App/EFCoreConsoleApp/Clients.db");
    }
}