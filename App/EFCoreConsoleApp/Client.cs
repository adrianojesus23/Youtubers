using App.ConcurrencyAsynchrony;

namespace App;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    //1-1
    public Order Order { get; set; }
    //1-M
    public List<Material> Materials { get; set; }
}