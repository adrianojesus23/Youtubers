using System.ComponentModel.DataAnnotations;

namespace StocksApi.ViewModels;

public class StockViewModelUpdate
{
    [StringLength(5)] 
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}