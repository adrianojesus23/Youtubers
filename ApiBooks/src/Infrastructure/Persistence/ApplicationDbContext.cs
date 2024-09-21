using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração das entidades
            modelBuilder.Entity<Book>().ToTable("Books");
            
            // Se ISBN é uma propriedade de Book, você deve configurá-lo assim
            modelBuilder.Entity<Book>()
                .Property<ISBN>(b => b.Isbn)
                .HasConversion<string>(
                    v => v.Value,
                    v => new ISBN(v));
            base.OnModelCreating(modelBuilder);
        }
    }
}