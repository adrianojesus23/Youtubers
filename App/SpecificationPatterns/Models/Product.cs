namespace App.SpecificationPatterns.Models;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsOnSale { get; set; }
}