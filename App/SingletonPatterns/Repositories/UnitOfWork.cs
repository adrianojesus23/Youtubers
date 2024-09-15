using App.SingletonPatterns.DbContexts;

namespace App.SingletonPatterns.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppPatternDbContext _appPattern;
    private IRepositoryClient _repositoryClient;

    public UnitOfWork(AppPatternDbContext dbContext)
    {
        _appPattern = dbContext;
    }

    public IRepositoryClient Clients => _repositoryClient ??= new RepositoryClient(_appPattern);

    public async Task<int> Save()
    {
        return await _appPattern.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _appPattern.Dispose();
    }
}