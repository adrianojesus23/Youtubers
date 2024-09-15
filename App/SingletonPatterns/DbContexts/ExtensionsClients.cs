using App.ConcurrencyAsynchrony;
using App.SingletonPatterns.Repositories;

namespace App.SingletonPatterns.DbContexts;

public static class ExtensionsClients
{
    public static Client ToModel(this ClientDto client)
    {
      
        
        return new Client()
        {
            Name = client.Name,
            Price = client.Price,
       
              Order = new Order { Name = "Order 4" , Id = 1},
              Materials = new List<Material>
              {
                  new Material { Description = "Material A", Id = 1},
                  new Material { Description = "Material B", Id = 2 },
                  new Material { Description = "Material C", Id = 3 },
              }
        };
    }
}