using ApiProduct.Models;

namespace ApiProduct.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);

        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
    }
}