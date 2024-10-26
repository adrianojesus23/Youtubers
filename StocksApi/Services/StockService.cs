using StocksApi.Extensions;
using StocksApi.Repositories;
using StocksApi.ViewModels;

namespace StocksApi.Services;

public class StockService:IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
    public async Task<IEnumerable<StockViewModel>> Get(string code = "", string description = "")
    {
        var stock = await _stockRepository.Get(code, description);

        return stock.Select(x => x.ToViewModel());
    }

    public async Task<StockViewModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Create(StockViewModelCreate model)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Guid id, StockViewModelUpdate model)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}