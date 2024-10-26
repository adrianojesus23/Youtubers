using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StocksApi.ViewModels;

public class LoginViewModel
{
    [Required] 
    [StringLength(20)] 
    [EmailAddress]
    public string Email { get; set; }
    [StringLength(12)] 
    [Required]
    [PasswordPropertyText]
    public string? Description { get; set; }
}