using ApiBookks.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiBookks.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
