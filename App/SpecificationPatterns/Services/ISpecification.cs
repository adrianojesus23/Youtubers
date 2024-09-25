using App.SpecificationPatterns.Models;
using Microsoft.IdentityModel.Tokens;

namespace App.SpecificationPatterns.Services;

public interface ISpecification<T>
{
    bool IsSatisFiedBy(T entity);
}


public class OnSaleSpefication: ISpecification<Product>
{
    public bool IsSatisFiedBy(Product entity)
    {
        return entity.IsOnSale;
    }
}

public class PriceGreaterThanSpecification : ISpecification<Product>
{
    private readonly decimal _minPrice;
    public PriceGreaterThanSpecification(decimal minPrice)
    {
        _minPrice = minPrice;
    }
    public bool IsSatisFiedBy(Product entity)
    {
        return entity.Price >= _minPrice;
    }
}

public class ValidateNameIsNullOrEmpty: ISpecification<Product>
{
    public bool IsSatisFiedBy(Product entity)
    {
        return !entity.Name.IsNullOrEmpty();
    }
}

public class AndSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _onSale;
    private readonly ISpecification<T> _price;

    public AndSpecification(ISpecification<T> onSale, ISpecification<T> price)
    {
        _onSale = onSale;
        _price = price;
    }
    
    public bool IsSatisFiedBy(T entity)
    {
        return _onSale.IsSatisFiedBy(entity) && _price.IsSatisFiedBy(entity);
    }
}