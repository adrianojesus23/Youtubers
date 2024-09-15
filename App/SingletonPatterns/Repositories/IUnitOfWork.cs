namespace App.SingletonPatterns.Repositories;

public interface IUnitOfWork: IDisposable
{
    IRepositoryClient Clients { get; }
    Task<int> Save();
}