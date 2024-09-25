namespace ApiProduct.DTOs.Queries
{
    public class GetByIdProdutoQuery
    {
        public int Id { get; set; }

        public GetByIdProdutoQuery(int id)
        {
            Id = id;
        }
    }
}
