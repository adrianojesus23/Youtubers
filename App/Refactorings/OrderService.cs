namespace App.Refactorings;

//Second approach
public class OrderService: IOrderService, ICalculate
{
    public decimal CalculateSubTotal(IEnumerable<OrderModel> orders)
    {
        var total = orders.Select(order =>
        {
            order.TotalPrice = order.Price * order.Quantity;

            return order.TotalPrice;
        });

        return total.Sum();
    }

    public decimal CalculateTax(decimal total)
    {
        return (total * ExtensionsOrderService._tax);
    }

    public double CalculateCircumference(double radius)
    {
        return (ExtensionsOrderService.Value * ExtensionsOrderService.PI * radius);
    }
}



