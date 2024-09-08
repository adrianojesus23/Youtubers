namespace App.ConcurrencyAsynchrony;

public static class ProcessTask
{
    public static void ProcessDate(this string data)
    {
        Console.WriteLine(data);
    }
    
    public static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++) {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} imprime {i}");
            Thread.Sleep(100); // Simula um trabalho
        }
    }
    
    public static async Task<string> FetchProducts(string url)
    {
        using HttpClient client = new HttpClient();
        var message = await client.GetAsync(url);
        message.EnsureSuccessStatusCode(); // Adiciona uma verificação para garantir que a resposta foi bem-sucedida
        return await message.Content.ReadAsStringAsync();
    }

    public static async Task<List<Client>> GetClients()
    {
        return await Task.FromResult(new List<Client>()
        {
            new Client(){ClientId = 1, Name = "Jesus"},
            new Client(){ClientId = 2, Name = "Laura"},
            new Client(){ClientId = 3, Name = "Gabriel"},
            new Client(){ClientId = 4, Name = "GABRIEL"},
            new Client(){ClientId = 5, Name = "gabriel"}
        });
    }
    
    public static async Task<List<Order>> GetOrders()
    {
        return await Task.FromResult(new List<Order>()
        {
            new Order(){Id = 1, Name = "SQL"},
            new Order(){Id = 2, Name = "C#"},
            new Order(){Id = 3, Name = "Java"}
        });
    }
    
    public static async Task<List<int>> GetNumbers()
    {
        return await Task.FromResult(new List<int>()
        {
            1,2,3,4,4,4,5,5,6,7,8,9,10,10
        });
    }
    
    public static async Task<List<List<int>>> GetMany()
    {
        return await Task.FromResult(new List<List<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 3, 4 }
        });
    }
}