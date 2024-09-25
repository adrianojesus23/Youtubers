using ApiProduct.DTOs.Commands;
using ApiProduct.Models;
using ApiProduct.Repositories;
using ApiProduct.Services;
using ApiProduct.Specifications;

namespace ApiProduct.DTOs.Handles
{
    public class CreateProdutoHandler : IHandler<CreateProdutoCommand, Result<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public CreateProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Result<Produto> Handle(CreateProdutoCommand request)
        {
            if (string.IsNullOrEmpty(request.Code))
                return Result<Produto>.Failure("O 'Code' do produto é obrigatório.");

            var produto = request.ToModel();

            _produtoRepository.Add(produto);

            return Result<Produto>.Success(produto);
        }
    }
}
