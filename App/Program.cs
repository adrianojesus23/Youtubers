using App;
using App.ConcurrencyAsynchrony;
using Dumpify;

//TOP 20 METHODS IN LINQ WITH E.G
var numbers = await ProcessTask.GetNumbers();
var numbersMany = await ProcessTask.GetMany();
var clients = await ProcessTask.GetClients();
var orders = await ProcessTask.GetOrders();
//1. Select
//var result = numbers.Select(x => x).Dump();
var result = clients.Select(x => x);
//2. Where
//result.Where(x => x.ClientId == 1);
//3. OrderBy
//result.OrderBy(x => x.Name).Dump();
//4. OrderByDescending
//result.OrderByDescending(x => x.ClientId).Dump();
//5. GroupBy
//result.GroupBy(x => x.Name).Dump();
//6. Join
var query = from c in clients
    join o in orders on c.ClientId equals o.Id
    select new
    {
        Id = c.ClientId,
        Client = c.Name,
        Order = o.Name
    };
//query.Dump();
//7. SelectMany
//numbersMany.SelectMany(x => x).Dump();
//8. Distinct
//numbers.Distinct().Dump();
//9. Union
var list1 = new List<int> { 1, 2, 3,8, 4, 5 };
var list3 = new List<int> { 6,7,8,9,4,5,10 };
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
numbers.Aggregate((acc,num)=> acc + num).Dump();