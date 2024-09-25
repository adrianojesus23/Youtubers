using ApiProduct.Repositories;
using ApiProduct.Services;

namespace ApiProduct.DTOs.Commands
{
    public class DeleteProdutoCommand 
    {
        public int Id { get; set; }

        public DeleteProdutoCommand(int id)
        {
            Id = id;
        }
    }

}
