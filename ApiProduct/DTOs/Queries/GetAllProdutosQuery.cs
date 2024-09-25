namespace ApiProduct.DTOs.Queries
{
    public class GetAllProdutosQuery
    {
        public string Code { get; internal set; }
        public string Description { get; internal set; }
        public bool? IsAvailable { get; internal set; }
        public decimal? Price { get; internal set; }

        public GetAllProdutosQuery(string code = null, string description = null, decimal? minPreco = null, bool? isAvailable = null)
        {
            Code = code;
            Description = description;
            Price = minPreco;
            IsAvailable = isAvailable;
        }
    }
}
