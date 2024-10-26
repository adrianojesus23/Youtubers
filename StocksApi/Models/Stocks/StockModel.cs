using System.ComponentModel.DataAnnotations;

namespace StocksApi.Models;

public class StockModel
{
    [Key] [Required] public Guid Id { get; set; }
    [Required] [StringLength(5)] public string Code { get; set; }
    [StringLength(5)] public string? Description { get; set; }
    public decimal? Price { get; set; }
}