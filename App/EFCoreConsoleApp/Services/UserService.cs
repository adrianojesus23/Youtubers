using App.EFCoreConsoleApp.Models;
using Bogus;
using EFCoreConsoleApp;
using Microsoft.EntityFrameworkCore;

namespace App.EFCoreConsoleApp.Services;

public class UserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static List<User> GenerateUsers(int count)
    {
        var userFaker = new Faker<User>()
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Profile, f => new Profile
            {
                Bio = f.Lorem.Sentence(),
            });

        return userFaker.Generate(count);
    }

    public async Task InsertMockData()
    {
        var users = GenerateUsers(5);

        await _dbContext.Users.AddRangeAsync(users);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users
            .Include(u => u.Profile)
            .ToListAsync();
    }
    
    public async Task<User?> GetById(int id)
    {
        return await _dbContext.Users
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<int> InsertBlog(Blog blog)
    {
        await _dbContext.Blogs.AddAsync(blog);

        await _dbContext.SaveChangesAsync();

        return blog.Id;
    }
    
    public async Task InsertPosts(List<Post> posts)
    {
        await _dbContext.Posts.AddRangeAsync(posts);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Blog>> GetBlogs()
    {
        return await _dbContext.Blogs
            .Include(x => x.Posts)
            .ToListAsync();
    }

    public async Task<Course> InsertCourse(Course course)
    {
        await _dbContext.Courses.AddAsync(course);
        await _dbContext.SaveChangesAsync();
        return course;
    }
    
    public async Task<Student> InsertStudent(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return student;
    }
    
    public async Task<StudentCourse> InsertStudentCourse(StudentCourse studentCourse)
    {
        await _dbContext.StudentCourses.AddAsync(studentCourse);
        await _dbContext.SaveChangesAsync();
        return studentCourse;
    }
    
    public async Task<List<StudentCourse>> GetStudentCourses()
    {
        return await _dbContext.StudentCourses
            .Include(x => x.Student)
            .Include(x => x.Course)
            .ToListAsync();
    }
}