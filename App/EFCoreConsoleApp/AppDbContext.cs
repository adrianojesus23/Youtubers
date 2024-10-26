using App.ConcurrencyAsynchrony;
using App.EFCoreConsoleApp;
using App.EFCoreConsoleApp.Configurations;
using App.EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Client = App.Client;

namespace EFCoreConsoleApp;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:/Youtubers/Youtubers/App/EFCoreConsoleApp/Clients.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SetUserProfileBuilder();
        modelBuilder.SetPostInBlogBuilder();
        modelBuilder.SetStudentCourseBuilder();
    }
}