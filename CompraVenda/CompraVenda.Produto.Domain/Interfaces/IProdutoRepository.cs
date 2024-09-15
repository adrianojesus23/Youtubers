namespace CompraVenda.Produto.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Entities.Produto>> GetAllAsync();
    Task<Entities.Produto> GetByIdAsync(int id);
    Task AddAsync(Entities.Produto produto);
    Task UpdateAsync(Entities.Produto produto);
    Task DeleteAsync(int id);
}