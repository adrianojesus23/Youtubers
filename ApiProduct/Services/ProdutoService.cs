using ApiProduct.DTOs;
using ApiProduct.DTOs.Commands;
using ApiProduct.DTOs.Queries;
using ApiProduct.Models;
using ApiProduct.Repositories;

namespace ApiProduct.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IHandler<CreateProdutoCommand, Result<Produto>> _createProdutoHandler;
        private readonly IHandler<DeleteProdutoCommand, Result<bool>> _deleteProdutoHandler;

        private readonly IHandler<GetAllProdutosQuery, Result<IEnumerable<Produto>>> _getAllProdutoHandler;
        private readonly IHandler<GetByIdProdutoQuery, Result<Produto>> _getByIdProdutoHandler;
        private readonly IHandler<UpdateProdutoCommand, Result<Produto>> _updateProdutoHandler;
        public ProdutoService(IHandler<CreateProdutoCommand, Result<Produto>> createProdutoHandler,
                              IHandler<DeleteProdutoCommand, Result<bool>> deleteProdutoHandler,
                              IHandler<GetAllProdutosQuery, Result<IEnumerable<Produto>>> getAllProdutoHandler,
                              IHandler<UpdateProdutoCommand, Result<Produto>> updateProdutoHandler,
                              IHandler<GetByIdProdutoQuery, Result<Produto>> getByIdProdutoHandler)
        {
            _createProdutoHandler = createProdutoHandler;
            _deleteProdutoHandler = deleteProdutoHandler;
            _getAllProdutoHandler = getAllProdutoHandler;
            _updateProdutoHandler = updateProdutoHandler;
            _getByIdProdutoHandler = getByIdProdutoHandler;
        }

      
        public Result<Produto> Create(CreateProdutoCommand command)
        {
            return _createProdutoHandler.Handle(command);
        }

        public Result<bool> Delete(DeleteProdutoCommand command)
        {
            return _deleteProdutoHandler.Handle(command);
        }

        public Result<IEnumerable<Produto>> GetAll(GetAllProdutosQuery query)
        {
           return _getAllProdutoHandler.Handle(query);
        }

        public Result<Produto> GetById(GetByIdProdutoQuery query)
        {
            return _getByIdProdutoHandler.Handle(query);
        }

        public Result<Produto> Update(UpdateProdutoCommand command)
        {
            return _updateProdutoHandler.Handle(command);
        }
    }
}
