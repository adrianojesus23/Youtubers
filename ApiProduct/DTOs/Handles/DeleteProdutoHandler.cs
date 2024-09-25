using ApiProduct.DTOs.Commands;
using ApiProduct.Repositories;
using ApiProduct.Services;

namespace ApiProduct.DTOs.Handles
{
    public class DeleteProdutoHandler : IHandler<DeleteProdutoCommand, Result<bool>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeleteProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Result<bool> Handle(DeleteProdutoCommand command)
        {
            var produto = _produtoRepository.GetById(command.Id);
            if (produto == null)
            {
                return Result<bool>.Failure("Produto não encontrado.");
            }

            _produtoRepository.Delete(produto);
            return Result<bool>.Success(true);
        }
    }
}
