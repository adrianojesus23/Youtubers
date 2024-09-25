using ApiProduct.Models;

namespace ApiProduct.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos;

        public ProdutoRepository()
        {
            var faker = new Bogus.Faker<Produto>()
                                 .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                                 .RuleFor(p => p.Description, f => f.Commerce.ProductName())
                                 .RuleFor(p => p.Code, f => f.Commerce.Ean13())
                                 .RuleFor(p => p.IsAvailable, f => f.Random.Bool())
                                 .RuleFor(p => p.Price, f => f.Random.Decimal(10, 100));

            _produtos = faker.Generate(10);
        }
        public void Add(Produto produto)
        {
           produto.Id = _produtos.Max(p=> p.Id) + 1;

            _produtos.Add(produto);
        }

        public void Delete(Produto produto)
        {
            _produtos.Remove(produto);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtos;
        }

        public Produto GetById(int id)
        {
            return _produtos.Find(p=>p.Id == id);
        }

        public void Update(Produto produto)
        {
            var existingProduto = GetById(produto.Id);

            if(existingProduto != null)
            {
                existingProduto.Price = produto.Price;
                existingProduto.Description = produto.Description;
            }
        }
    }
}
