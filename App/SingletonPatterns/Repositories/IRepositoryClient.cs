namespace App.SingletonPatterns.Repositories;

public interface IRepositoryPattern
{
    Task<int> Create(ClientDto client);
    Task<ClientDto> GetById(int id);
    Task<IEnumerable<ClientDto>> Get();
    Task<int> Update(int id, ClientDto client);
    Task<int> Delete(int id);
}

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}