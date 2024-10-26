using StocksApi.Models;

namespace StocksApi.Repositories;

public interface IStockRepository
{
    Task<IEnumerable<StockModel>> Get(string code = "", string description = "");
    Task<StockModel> GetById(Guid id);
    Task Create(StockModel model);
    Task Update(StockModel model);
    Task Delete(Guid id);
}