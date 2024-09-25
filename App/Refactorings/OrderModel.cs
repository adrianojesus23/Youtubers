namespace App.Refactorings;

public class OrderModel
{
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsPremiumMenber { get; set; }
}