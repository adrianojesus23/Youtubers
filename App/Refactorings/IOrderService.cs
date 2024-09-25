namespace App.Refactorings;

public interface IOrderService
{
    decimal CalculateSubTotal(IEnumerable<OrderModel> orders);
    decimal CalculateTax(decimal total);
}

public interface ICalculate
{
   double CalculateCircumference(double radius);
}