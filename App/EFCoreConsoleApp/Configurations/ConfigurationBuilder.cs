using App.EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace App.EFCoreConsoleApp.Configurations;

public static class ConfigurationBuilder
{
    public static void SetUserProfileBuilder(this ModelBuilder modelBuilder)
    {
        //Configuration relation: 1-1 in E.F and delete
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(up => up.User)
            .HasForeignKey<Profile>(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }


    public static void SetPostInBlogBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(p => p.Blog)
            .HasForeignKey(p => p.BlogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public static void SetStudentCourseBuilder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });
        
        modelBuilder.Entity<StudentCourse>()
            .HasOne(b => b.Student)
            .WithMany(s=> s.StudentCourses)
            .HasForeignKey(s=> s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        modelBuilder.Entity<StudentCourse>()
            .HasOne(b => b.Course)
            .WithMany(s=> s.StudentCourses)
            .HasForeignKey(s=> s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}