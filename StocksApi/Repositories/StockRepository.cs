using Microsoft.EntityFrameworkCore;
using StocksApi.DbContexts;
using StocksApi.Models;

namespace StocksApi.Repositories;

public class StockRepository: IStockRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StockRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<IEnumerable<StockModel>> Get(string code = "", string description = "")
    {
        var stocks = _applicationDbContext.Stocks
            .Where(x => ((string.IsNullOrEmpty(code) || x.Code.Contains(code) ) ||
                         (string.IsNullOrEmpty(description) || 
                          x.Description.StartsWith(description) )));

        return await stocks.ToListAsync();
    }

    public async Task<StockModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Create(StockModel model)
    {
        throw new NotImplementedException();
    }

    public async Task Update(StockModel model)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}