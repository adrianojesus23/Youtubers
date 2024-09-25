using ApiProduct.DTOs;
using ApiProduct.DTOs.Commands;
using ApiProduct.DTOs.Queries;
using ApiProduct.Models;

namespace ApiProduct.Services
{
    public interface IProdutoService
    {
        Result<Produto> Create(CreateProdutoCommand command);
        Result<Produto> Update(UpdateProdutoCommand command);
        Result<IEnumerable<Produto>> GetAll(GetAllProdutosQuery query);
        Result<Produto> GetById(GetByIdProdutoQuery query);
        Result<bool> Delete(DeleteProdutoCommand command);
    }
}