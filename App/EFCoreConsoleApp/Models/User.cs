namespace App.EFCoreConsoleApp.Models;

public class User
{
    //1-1
    public int Id { get; set; }
    public string Name { get; set; }
    public Profile Profile { get; set; }
}