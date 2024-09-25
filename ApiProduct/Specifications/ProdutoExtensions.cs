using ApiProduct.DTOs.Commands;
using ApiProduct.Models;

namespace ApiProduct.Specifications
{
    public static class ProdutoExtensions
    {
        public static Produto ToModel(this CreateProdutoCommand request)
        {
            if(request is null)
            {
                return default(Produto);
            }

            return new Produto
            {
                Description = request.Description,
                Code = request.Code,
                IsAvailable = request.IsAvailable,
                Price = request.Price,
            };
        }

        public static Produto ToModel(this UpdateProdutoCommand request)
        {
            if (request is null)
            {
                return default(Produto);
            }

            return new Produto
            {
                Id = request.Id,
                Description = request.Description,
                Code = request.Code,
                IsAvailable = request.IsAvailable,
                Price = request.Price,
            };
        }

      
    }
}
