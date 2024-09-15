namespace App.SingletonPatterns.Repositories;

public class RepositoryPattern: IRepositoryPattern
{
    public RepositoryPattern()
    {
        
    }
    public async Task<int> Create(ClientDto client)
    {
        throw new NotImplementedException();
    }

    public async Task<ClientDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientDto>> Get()
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(int id, ClientDto client)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }
}