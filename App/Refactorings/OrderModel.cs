namespace App.Refactorings;

public class Order
{
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsPremiumMenber { get; set; }
}