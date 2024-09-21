using App.DapperBulks;
using App.OOP;
using App.Refactorings;
using App.SpecificationPatterns.Models;
using App.SpecificationPatterns.Services;
using Dumpify;

//Any() Exists() Count()
var listLivros = Livro.GetListLivros();
//Any() && Count()
var enumerbleLivros = Livro.GetLivros();

//********************************************************
//Vazia vs Null

if (listLivros.Count > 10 || 
    listLivros.Any() || 
    listLivros.Exists(x=> x.Autor.Equals("Pedro")))
{
    listLivros.Dump();
}
else
{
    Console.WriteLine("Não há livros");
}













//POO
//Introdução  
//Classe e Objeto (new)
// Livro livro01 = new Livro("C#", "Jesus", 240);
// livro01.GetTitulo().Dump();
// LivroDigital livro02 = new LivroDigital("POO", "Pedro", 140, 20);
// livro01.Dump();
// livro02.Ler();
//Encapsulamento  (public, private, protected, internal)

//Herança 
//Polimorfismo Tipos(Sobrecarga ->Compile-time ,Substituição  -> Runtime) 
//Abstração 











//Teste().Dump();

// void Teste()
// {
// IOrderService orderService = new OrderService();
//
// var orders = ExtensionsOrderService.GetOrders();
// Console.WriteLine("Second approach");
// decimal totalDecimal = orderService.CalculateSubTotal(orders);
// decimal taxDecimal = orderService.CalculateTax(totalDecimal);
// (totalDecimal + taxDecimal).Dump();
//
// Console.WriteLine("First approach");
// decimal total = orders.CalculateSubTotal();
// decimal tax = total.CalculateTax();
// decimal totalTax = total + tax;
// totalTax.Dump();
//
// double value = 20;
// var result = value.CalulateCircumference();
// result.Dump();
//}


//********************************************************
//1. Basic Switch:
// string Teste()
// {
//     int day = 3;
//     switch (day)
//     {
//         case 1:
//             return "Monday";
//             break;
//         case 3:
//             return "Tuesday";
//             break;
//         default:
//             return "Sunday";
//             break;
//     }
// }
//2. Switch with when:
// string Teste()
// {
//     int temp = -1;
//     switch (temp)
//     {
//         case int t when t < 0:
//             return "Freezing";
//             break;
//         case int t when t >= 0 && t <= 15:
//             return "Cold";
//             break;
//         default:
//             return "Hot";
//             break;
//     }
// }
//3. Switch with Tuples:
// string Teste()
// {
//     (int day, bool isHoliday) = (2, true);
//     
//     switch (day, isHoliday)
//     {
//         case (1, true):
//             return "Holiday";
//             break;
//         case (25,_):
//             return "Natal";
//             break;
//         case (_,false):
//             return "Weekend";
//             break;
//         default:
//             return "No day";
//             break;
//     }
// }
//4. Switch Expressions:
// string Teste()
// {
//     int day = 1;
//     string result = day switch
//     {
//         1 => "Monday",
//         2 => "Tuesday",
//         _ => "Unknown day"
//     };
//
//     return result;
// }
//5. Positional Patterns:
string Teste()
{
    (int x, int y) point = (3, 0);
    
    string result = point switch
    {
        (3,2) => "Monday",
        (var x, 0) => $"Tuesday {x}",
        _ => "Unknown day"
    };

    return result;
}
//6. Type Patterns:
// string Teste()
// {
//     object obj = "42 => Jesus";
//     
//     string result = obj switch
//     {
//        int i => $"Integer {i}",
//         string s => $"Tuesday {s}",
//         _ => "Unknown"
//     };
//
//     return result;
// }
//7. Recursive Patterns:

// string Teste()
// {
//     Point point = new Point(2, 3);
//     
//     string result = point switch
//     {
//         { X:1,Y:3} => $"Integer {point.X} {point.Y}",
//         { X:1} => $"Integer {point.X} {point.Y}",
//         { Y:3} => $"Integer {point.X} {point.Y}",
//         _ => "Unknown"
//     };
//
//     return result;
// }
//8. Constant Expressions in Switch:
// string Teste()
// {
//     int age = 14;
//     string result = age switch
//     {
//           var a when a >= 0 && a <= 12 => "Child",
//           var a when a >= 13 && a <= 17 => "Teenager",
//           var a when a >= 18 => "Adult",
//           _ => "Unknown"
//     };
//
//     return result;
// }
//9. Pattern Combinations (and, or, not):

// string Teste()
// {
//     int age = 14;
//     
//     string result = age switch
//     {
//         var a when a > 0 && a < 18 => "Minor",     // Use '&&' for logical AND
//         var a when a >= 18 && a < 65 => "Adult",
//         var a when a >= 65 => "Senior",
//         _ => "Invalid age"
//     };
//
//     return result;
// }







var customers = new List<Customer>
{
    new Customer { Id = 1, Name = "John Pedro", Email = "john.pedro@example.com" },
    new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
    new Customer { Id = 3, Name = "Alice Miguel", Email = "alice.miguel@example.com" }
};

//TestDapperBulk();

void TestDapperBulk()
{
    string connectionString =
        "Data Source=LAPTOP-GGDPPIDL;Initial Catalog=AP;Persist Security Info=True;User ID=Steve;Password=Wwil12345!;TrustServerCertificate=True;";
    var connectionManager = new DbConnectionManager(connectionString);
    var databaseAdapter = new DatabaseAdapter(connectionManager);

    databaseAdapter.BulkUpdate(customers);
    databaseAdapter.BulkInsert(customers);
    databaseAdapter.BulkMarge(customers);
    databaseAdapter.BulkDelete(customers);

    var listCustomers = databaseAdapter.GetCustomers();

    //listCustomers.Dump();
}


//TesteSpecification();


void TesteSpecification()
{
    var onSaleSpec = new OnSaleSpefication();
    var priceSpec = new PriceGreaterThanSpecification(20);
    var nameSpec = new ValidateNameIsNullOrEmpty();

    var validate = new AndSpecification<Product>(onSaleSpec, priceSpec);

    // foreach (var product in products.Where(prod => validate.IsSatisFiedBy(prod)))
    // {
    //     Console.WriteLine($"Producto:{product.Name} Preço:{product.Price} Em saldo:{product.IsOnSale}");
    // }
}


// class Program
// {
//     static async Task Main(string[] args)
//     {
//         // Configure services
//         var serviceProvider = new ServiceCollection()
//             .AddDbContext<AppPatternDbContext>(options =>
//                 options.UseSqlite("Data Source=C:/Youtubers/Youtubers/App/EFCoreConsoleApp/Clients.db"))
//             .AddScoped<IUnitOfWork, UnitOfWork>()
//             .BuildServiceProvider();
//
//         // Resolve the UnitOfWork from the service provider
//         using (var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
//         {
//             // Add a new client
//             
//              var db = await unitOfWork.Clients.GetContext();
//                 db.Database.EnsureCreatedAsync();
//
//             if (!db.Clients.Any())
//             {
//                 await db.Clients.AddRangeAsync(Data.GetClients());
//                 await db.SaveChangesAsync();
//             }
//
//             var newClient = new ClientDto() { Name = "John Doe", Price = 12};
//            
//             await db.AddAsync(Data.GetClient());
//             await db.SaveChangesAsync();
//
//             // Get all clients
//             var clients = await unitOfWork.Clients.Get();
//             foreach (var client in clients)
//             {
//                 Console.WriteLine($"Client: {client.Name}");
//             }
//
//             // Update a client
//             var clientToUpdate = await unitOfWork.Clients.GetById(1); // Assuming ID 1 exists
//             if (clientToUpdate != null)
//             {
//                 clientToUpdate.Name = "Jane Doe";
//                 await unitOfWork.Clients.Update( clientToUpdate.Id,new ClientDto()
//                 {
//                      Price = clientToUpdate.Price,
//                      Name = clientToUpdate.Name,
//                      Id = clientToUpdate.Id
//                 });
//                 await unitOfWork.Save();
//             }
//
//             // Delete a client
//             await unitOfWork.Clients.Delete(1); // Assuming ID 1 exists
//             await unitOfWork.Save();
//         }
//     }
// }


//Understanding the Principles of OOP in C#

/*
 * 1. Encapsulation
 * 2. Inheritance
 * 3. Polymorphism
 * 4. Abstraction
 */
// public class Car
// {
//     public string Brand { get; set; }
// }


//Async/ToList,Save,EnsureCreated,Migrate

//  await context.Database.EnsureCreatedAsync();
//
// if (!context.Clients.Any())
// {
//     await context.Clients.AddRangeAsync(Data.GetClients());
//     await context.SaveChangesAsync();
// }

// var result = await context.Clients
//                                .Include(x=> x.Order)
//                                .Include(x=> x.Materials)
//                                .FirstOrDefaultAsync(x=> x.Id == 909);
// result.Dump();

//ToFrozenSet
// var list = new List<int> { 1, 2, 3,3,4, 4, 5 };
// var immutList = list.ToImmutableList();
//immutList.Dump();
//ToHashSet
//list.ToHashSet().Dump();
//ForEachAsync
//var result = await context.Clients.ToListAsync();
//result.ForEach(x=> x.Dump());
//ToLookup
//result.ToLookup(x=> x.Name).Dump();


//1. Add


//2. AddRange

//3. Update

//4. UpdateRange
//5. Remove
//6. RemoveRange
//7. Find

//8. FirstOrDefault

//9. SingleOrDefault
//10. First
//*************************************
//11. Single
//12. Where

//13. Any
//14. Count
//15. Max
//16. Min
//17. Sum

//18. Average
//19. OrderBy
//20. OrderByDescending
//*****************************************
//21. ThenBy
//22. ThenByDescending


//client.Dump();
//23. Include
//24. Include → ThenInclude
//25. AsNoTracking
//26. Attach
//32. Skip
//33. Take
//34. GroupBy
//35. Join
//36. Distinct
//37. Contains
//40. Entry

// var clients = await context.Clients.ToListAsync();
// var orders = await context.Orders.ToListAsync();
// var clientOrders = clients.Join(
//     orders,
//     client => client.Order.Id,
//     order => order.Id,
//     ((client, order) => new
//     {
//         ClientName = client.Name,
//         OrderName = order.Name
//     })
// ).ToList();

//clientOrders.Dump();

// var client = await context.Clients
//     .AsNoTracking()
//     .Include(x => x.Order)
//     .Include(x => x.Materials)
//     .OrderBy((x => x.Id))
//     .ThenByDescending(x => x.Name)
//     .ToListAsync();
// client.Dump();


// async Task CreateClients(AppDbContext appDbContext)
// {
//     var client1 = new Client { Name = "Jesus", Price = 100, Order = new Order()
//     {
//          Id = 1, Name = "Order 1"
//     }, Materials = new List<Material>()
//     {
//         new Material()
//         {
//             Id = 1, Description = "M1"
//         }
//     }};
//     var client2 = new Client { Name = "Lucrécia", Price = 200, Order = new Order()
//     {
//         Id = 2, Name = "Order 2"
//     }, Materials = new List<Material>()
//     {
//         new Material()
//         {
//             Id = 2, Description = "M2"
//         }
//     }};
//     
//     var client3 = new Client { Name = "Gabriel", Price = 100, Order = new Order()
//     {
//         Id = 3, Name = "Order 3"
//     }, Materials = new List<Material>()
//     {
//         new Material()
//         {
//             Id = 3, Description = "M3"
//         }
//     }};
//     
//     List<Client> clients = new List<Client>()
//     {
//         client1, client2, client3
//     };
//    
//      await context.Clients.AddRangeAsync(clients);
//      await context.SaveChangesAsync();
// }


//TOP 20 METHODS IN LINQ WITH E.G
// var numbers = await ProcessTask.GetNumbers();
// var numbersMany = await ProcessTask.GetMany();
// var clients = await ProcessTask.GetClients();
// var orders = await ProcessTask.GetOrders();
//1. Select
//var result = numbers.Select(x => x).Dump();
// var result = clients.Select(x => x);
//2. Where
//result.Where(x => x.ClientId == 1);
//3. OrderBy
//result.OrderBy(x => x.Name).Dump();
//4. OrderByDescending
//result.OrderByDescending(x => x.ClientId).Dump();
//5. GroupBy
//result.GroupBy(x => x.Name).Dump();
//6. Join
// var query = from c in clients
//     join o in orders on c.ClientId equals o.Id
//     select new
//     {
//         Id = c.ClientId,
//         Client = c.Name,
//         Order = o.Name
//     };
//query.Dump();
//7. SelectMany
//numbersMany.SelectMany(x => x).Dump();
//8. Distinct
//numbers.Distinct().Dump();
//9. Union
// var list1 = new List<int> { 1, 2, 3,8, 4, 5 };
// var list3 = new List<int> { 6,7,8,9,4,5,10 };
//list1.Union(list3).Dump();
//10. Intersect
//list1.Intersect(list3).Dump();
//11. Except
//7list1.Except(list3).Dump();
//list3.Except(list1).Dump();
//12. First
//clients.First(x=> x.ClientId == 24).Dump();
//13. FirstOrDefault Add Find
//clients.FirstOrDefault(x=> x.ClientId == 3).Dump();
//14. Single
//clients.Single(x=> x.ClientId == 32).Dump();
//15. SingleOrDefault
//clients.FindLastIndex(x=> x.ClientId == 2).Dump();

//16. Any
//clients.Any(x=> x.ClientId == 3).Dump();
//17. All
//clients.All(x=> x.ClientId == 3).Dump();
//18. Count
//clients.Where(x=>x.Name.("L", StringComparison.CurrentCultureIgnoreCase)).Dump();
//19. Sum
//clients.Sum(x => x.Name.Length).Dump();
//20. Aggregate
//numbers.Aggregate((acc,num)=> acc + num).Dump();