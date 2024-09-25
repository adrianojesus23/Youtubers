using ApiProduct.DTOs.Queries;
using ApiProduct.Models;
using ApiProduct.Repositories;
using ApiProduct.Services;
using ApiProduct.Specifications;

namespace ApiProduct.DTOs.Handles
{
    public class GetAllProdutosHandler : IHandler<GetAllProdutosQuery, Result<IEnumerable<Produto>>>
    {
        private readonly IProdutoRepository produtoRepository;

        public GetAllProdutosHandler(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }
        public Result<IEnumerable<Produto>> Handle(GetAllProdutosQuery request)
        {
            var allProdutos = produtoRepository.GetAll();

             if(CheckIsEmpty(allProdutos))
                return Result<IEnumerable<Produto>>.Failure("Não há produtos");

            var filterProdutos = allProdutos.Where(ProdutoSpecification.CombineAll(request.Code, request.Description, request.IsAvailable, request.Price));

            if (CheckIsEmpty(filterProdutos))
                return Result<IEnumerable<Produto>>.Success(allProdutos);

            return Result<IEnumerable<Produto>>.Success(filterProdutos);
        }

        private static bool CheckIsEmpty(IEnumerable<Produto> filterProdutos)
        {
            return (!filterProdutos.Any());
        }
    }
}
