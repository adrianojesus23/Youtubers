namespace ApiProduct.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

    }
}
