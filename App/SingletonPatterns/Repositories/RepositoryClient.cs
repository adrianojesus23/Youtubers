using App.SingletonPatterns.DbContexts;
using App.SingletonPatterns.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace App.SingletonPatterns.Repositories;

public class RepositoryClient: IRepositoryClient
{
    private readonly AppPatternDbContext _appPatternDbContext;

    public RepositoryClient(AppPatternDbContext appPatternDbContext)
    {
        _appPatternDbContext = appPatternDbContext;
    }

    public async Task<AppPatternDbContext> GetContext()
    {
        return await Task.FromResult(_appPatternDbContext);
    }
    public async Task Create(ClientDto clientDto)
    {
        await _appPatternDbContext.Clients.AddAsync(clientDto.ToModel());
    }

    public async Task<Client?> GetById(int id)
    {
        return await _appPatternDbContext.Clients.FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<IEnumerable<Client>> Get()
    {
        return await _appPatternDbContext.Clients.ToListAsync();
    }

    public async Task Update(int id, ClientDto clientDto)
    {
        var client = await _appPatternDbContext.Clients.FindAsync(id);

        if (client is not null)
        {
            var updateClient = clientDto.ToModel();
            updateClient.Id = client.Id;
            
            _appPatternDbContext.Clients.Update(updateClient);
        }
    }

    public async Task Delete(int id)
    {

        var client = await _appPatternDbContext.Clients.FindAsync(id);

        if (client is not null)
             _appPatternDbContext.Clients.Remove(client);
    }
}