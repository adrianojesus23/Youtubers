using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StocksApi.Models;

namespace StocksApi.DbContexts;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
    :base(contextOptions)
    {
        
    }
    
    public DbSet<StockModel> Stocks { get; set; }
}