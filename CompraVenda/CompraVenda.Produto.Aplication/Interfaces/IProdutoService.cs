using CompraVenda.Produto.Domain.DTOs;

namespace CompraVenda.Produto.Domain.Entities;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> GetAllAsync();
    Task<ProdutoDto> GetByIdAsync(int id);
    Task AddAsync(ProdutoDto produtoDto);
    Task UpdateAsync(ProdutoDto produtoDto);
    Task DeleteAsync(int id);
}