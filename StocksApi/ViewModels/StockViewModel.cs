namespace StocksApi.ViewModels;

public class StockViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}