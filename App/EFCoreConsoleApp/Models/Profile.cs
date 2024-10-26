namespace App.EFCoreConsoleApp.Models;

public class Profile
{
    //1-1
    public int Id { get; set; }
    public string Bio { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}