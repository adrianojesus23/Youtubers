using System.Runtime.InteropServices.JavaScript;
using App.ConcurrencyAsynchrony;
using Microsoft.EntityFrameworkCore;

namespace App.SingletonPatterns.DbContexts;

public class AppPatternDbContext: DbContext
{
    private static AppPatternDbContext _appPattern;

    private static readonly object _lock = new object();
    
    public AppPatternDbContext(DbContextOptions<AppPatternDbContext> options): base(options)
    {
        
    }

    public static AppPatternDbContext Instance
    {
        get
        {
            lock (_lock)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppPatternDbContext>();

                optionsBuilder.UseSqlite("Data Source=C:/Youtubers/Youtubers/App/EFCoreConsoleApp/Clients.db");

                _appPattern = new AppPatternDbContext(optionsBuilder.Options);
            }

            return _appPattern;
        }
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Material> Materials { get; set; }

}