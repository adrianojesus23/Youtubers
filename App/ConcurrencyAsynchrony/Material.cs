namespace App.ConcurrencyAsynchrony;

public class Material
{
    public int Id { get; set; }
    public string Description { get; set; }

    private int x = 2;

    public void RefM(ref int x)
    {
        RefO(out int y);
        Console.Write(x);
        Console.Write(y);
    }

    public void RefO(out int y)
    {
        y = 2;
        Console.Write(y);
        var m = new Meta();
    }


}

public struct Mota
{
    
}

public record Vehicle(int number, string name);

public static class VehicleImplementation
{
    public static Vehicle GetVehicle(int number)
    {
        var vehicle = new Vehicle(number, "");

        var newVehicle = vehicle with
        {
            name = "Jesus"
        };

        return newVehicle;
    }
}