using StocksApi.Models;
using StocksApi.ViewModels;

namespace StocksApi.Services;

public interface IStockService
{
    Task<IEnumerable<StockViewModel>> Get(string code = "", string description = "");
    Task<StockViewModel> GetById(Guid id);
    Task Create(StockViewModelCreate model);
    Task Update(Guid id,StockViewModelUpdate model);
    Task Delete(Guid id);
}