using ApiProduct.DTOs.Commands;
using ApiProduct.Models;
using ApiProduct.Repositories;
using ApiProduct.Services;
using ApiProduct.Specifications;

namespace ApiProduct.DTOs.Handles
{
    public class UpdateProdutoHandler : IHandler<UpdateProdutoCommand, Result<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public Result<Produto> Handle(UpdateProdutoCommand request)
        {
            var produto = _produtoRepository.GetById(request.Id);

            if(produto == null)
            {
                return Result<Produto>.Failure("Produto não encontrado");
            }

            var produtoResult = request.ToModel();

            _produtoRepository.Update(produtoResult);

            return Result<Produto>.Success(produtoResult);
        }
    }
}
