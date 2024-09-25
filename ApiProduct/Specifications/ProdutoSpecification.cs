using ApiProduct.Models;

namespace ApiProduct.Specifications
{
    public class ProdutoSpecification
    {
        public static Func<Produto, bool> ByPrecoGreaterThan(decimal minPreco)
        {
            return p => p.Price > minPreco;
        }

        public static Func<Produto, bool>ByCode(string code)
        {
            return p=> string.IsNullOrEmpty(code) || p.Code.Contains(code, StringComparison.OrdinalIgnoreCase);
        }

        public static Func<Produto, bool> ByDescription(string description)
        {
            return p => string.IsNullOrEmpty(description) || p.Description.Contains(description, StringComparison.OrdinalIgnoreCase);
        }

        public static Func<Produto, bool> ByAvailability(bool? isAvailable)
        {
            return p =>  !isAvailable.HasValue || p.IsAvailable == isAvailable.Value;
        }

        public static Func<Produto, bool> CombineAll(string code, string description, bool? isAvailable, decimal? price)
        {
            return p => ByCode(code)(p) &&
                       ByDescription(description)(p) &&
                       (!price.HasValue || ByPrecoGreaterThan(price.Value)(p)) &&
                       ByAvailability(isAvailable)(p);
        }
    }
}
