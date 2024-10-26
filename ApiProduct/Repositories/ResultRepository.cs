using ApiProduct.Models;
using IResultGeneric;

namespace ApiProduct.Repositories
{
    public class ResultRepository : IResult<Produto>
    {
        private List<Produto> _produtos = new List<Produto>();

        public Result<Produto> Create(Produto result)
        {
             _produtos.Add(result);

            return Result<Produto>.Success(result);
        }

        public Result<Produto> Delete(int id)
        {
            var produto = _produtos.FirstOrDefault(x => x.Id == id);

            if (produto is null)
                return Result<Produto>.Failure("Produto não encontrado");

            _produtos.Remove(produto);

            return Result<Produto>.Success(produto);
        }

        public Result<IEnumerable<Produto>> GetAll(string? code = null)
        {
            if(!string.IsNullOrEmpty(code))
            {
                var produtos  = _produtos.Where(x => x.Code.Contains(code));

                return Result<IEnumerable<Produto>>.Success(produtos);
            }

            return Result<IEnumerable<Produto>>.Success(_produtos);
        }

        public Result<Produto> GetById(int id)
        {
            var produto = _produtos.FirstOrDefault(x => x.Id == id);

            if (produto is null)
                return Result<Produto>.Failure("Produto não encontrado");

            return Result<Produto>.Success(produto);
        }

        public Result<Produto> Update(Produto result)
        {
            var produto = _produtos.FirstOrDefault(x => x.Id == result.Id);

            if (produto is null)
                return Result<Produto>.Failure("Produto não encontrado");
          
            produto.Price = result.Price;
            produto.IsAvailable = result.IsAvailable;


            return Result<Produto>.Success(produto);
        }
    }
}
