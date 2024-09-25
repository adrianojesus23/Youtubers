namespace App.Refactorings;

//First approach
public static class ExtensionsOrderService
{
    public static readonly decimal _tax = new decimal(0.2);
    public static readonly double PI = 3.14;
    public const double Value = 2;

    public static decimal CalculateSubTotal(this IEnumerable<OrderModel> orders)
    {
        var total = orders.Select(order =>
        {
            order.TotalPrice = order.Price * order.Quantity;

            return order.TotalPrice;
        });

        return total.Sum();
    }

    public static decimal CalculateTax(this decimal total)
    {
        return (total * _tax);
    }

    public static double CalulateCircumference(this double radius)
    {
        return (Value * PI * radius);
    }

    public static IEnumerable<OrderModel> GetOrders()
    {
        return new List<OrderModel>()
        {
            new OrderModel()
            {
                IsPremiumMenber = true,
                Price = 2,
                Quantity = 4,
                TotalPrice = 0
            },
            new OrderModel()
            {
                IsPremiumMenber = true,
                Price = 3,
                Quantity = 5,
                TotalPrice = 0
            }
        };
    }
}