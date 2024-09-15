namespace App.SingletonPatterns.Repositories;

public interface IUnitWork: IDisposable
{
    IRepositoryPattern Clients { get; }
    Task<int> Save();
}