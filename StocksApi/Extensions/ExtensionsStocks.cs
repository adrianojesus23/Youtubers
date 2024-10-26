using StocksApi.Models;
using StocksApi.ViewModels;

namespace StocksApi.Extensions;

public static class ExtensionsStocks
{
    public static StockViewModel ToViewModel(this StockModel stockModel)
    {
        if (stockModel is null) return default;

        return new StockViewModel
        {
            Id = stockModel.Id,
            Code = stockModel.Code,
            Description = stockModel.Description,
            Price = stockModel.Price
        };
    }
}