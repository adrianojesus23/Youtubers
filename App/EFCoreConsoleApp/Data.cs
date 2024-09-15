using App.ConcurrencyAsynchrony;

namespace App.EFCoreConsoleApp;

public static class Data
{
    public static List<Material> GetMaterials()
    {
        return new List<Material>
        {
            new Material { Description = "Material A" },
            new Material { Description = "Material B" },
            new Material { Description = "Material C" },
        };
    }

    public static Material GetMaterial()
    {
        return new Material { Description = "Material D" };
    }

    public static List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order { Name = "Order 1" },
            new Order { Name = "Order 2" },
            new Order { Name = "Order 3" },
        };
    }

    public static Order GetOrder()
    {
        return new Order { Name = "Order 4" };
    }

    public static Client GetClient()
    {
        var order = GetOrder();
        
        var materials = GetMaterials();
        
        return new Client
        {
            Name = "Client 9", Price = 99, Order = order,
            Materials = materials
        };
    }


    public static List<Client> GetClients()
    {
        var orders = GetOrders();
        var materials = GetMaterials();
        return new List<Client>
        {
            new Client
            {
                Name = "Client 1", Price = 100, Order = orders[0],
                Materials = new List<Material> { materials[0], materials[1] }
            },
            new Client
            {
                Name = "Client 2", Price = 200, Order = orders[1],
                Materials = new List<Material> { materials[1], materials[2] }
            },
            new Client
            {
                Name = "Client 3", Price = 300, Order = orders[2],
                Materials = new List<Material> { materials[0], materials[2] }
            },
            new Client
            {
                Name = "Client 4", Price = 150, Order = orders[0], Materials = new List<Material> { materials[1] }
            },
            new Client
            {
                Name = "Client 5", Price = 250, Order = orders[1],
                Materials = new List<Material> { materials[0], materials[2] }
            },
            new Client
            {
                Name = "Client 6", Price = 350, Order = orders[2], Materials = new List<Material> { materials[2] }
            },
            new Client
            {
                Name = "Client 7", Price = 400, Order = orders[0],
                Materials = new List<Material> { materials[0], materials[1] }
            },
            new Client
            {
                Name = "Client 8", Price = 500, Order = orders[1],
                Materials = new List<Material> { materials[1], materials[2] }
            },
            new Client
            {
                Name = "Client 9", Price = 600, Order = orders[2], Materials = new List<Material> { materials[0] }
            },
            new Client
            {
                Name = "Client 10", Price = 700, Order = orders[0],
                Materials = new List<Material> { materials[0], materials[1], materials[2] }
            }
        };
    }
}