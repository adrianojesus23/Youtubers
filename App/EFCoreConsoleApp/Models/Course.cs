namespace App.EFCoreConsoleApp.Models;

public class Course
{
    public int Id { get; set; }
    public string  Title { get; set; }
    public List<StudentCourse> StudentCourses { get; set; }
}