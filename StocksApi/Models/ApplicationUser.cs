using Microsoft.AspNetCore.Identity;
using StocksApi.Models.Enums;

namespace StocksApi.Models;

public class ApplicationUser: IdentityUser
{
    public string FullName { get; set; }
    public TypeUser TypeUser { get; set; }
}