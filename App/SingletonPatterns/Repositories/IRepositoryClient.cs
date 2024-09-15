using System.Runtime.CompilerServices;
using App.SingletonPatterns.DbContexts;

namespace App.SingletonPatterns.Repositories;

public interface IRepositoryClient
{
    Task Create(ClientDto client);
    Task<Client?> GetById(int id);
    Task<IEnumerable<Client>> Get();
    Task Update(int id, ClientDto client);
    Task Delete(int id);
    Task<AppPatternDbContext> GetContext();
}

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

