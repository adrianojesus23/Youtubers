using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StocksApi.Models.Enums;

namespace StocksApi.ViewModels;

public class RegisterViewModel
{
    [Required] 
    [StringLength(20)] 
    [EmailAddress]
    public string Email { get; set; }
    [StringLength(12)] 
    [Required]
    [PasswordPropertyText]
    public string? Description { get; set; }
    public TypeUser TypeUser { get; set; }
}