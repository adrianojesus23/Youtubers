using System.ComponentModel.DataAnnotations;

namespace StocksApi.ViewModels;

public class StockViewModelCreate
{
    [Required] [StringLength(5)] 
    public string Code { get; set; }
    [StringLength(5)] 
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}