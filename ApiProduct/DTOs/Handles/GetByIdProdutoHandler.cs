using ApiProduct.DTOs.Queries;
using ApiProduct.Models;
using ApiProduct.Repositories;
using ApiProduct.Services;

namespace ApiProduct.DTOs.Handles
{
    public class GetByIdProdutoHandler : IHandler<GetByIdProdutoQuery, Result<Produto>>
    {
        private readonly IProdutoRepository produtoRepository;

        public GetByIdProdutoHandler(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public Result<Produto> Handle(GetByIdProdutoQuery request)
        {
            var produto = produtoRepository.GetById(request.Id);

            if (produto is null)
                return Result<Produto>.Failure("O produto não foi encontrado");

            return Result<Produto>.Success(produto);
        }
    }
}
