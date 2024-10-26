using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StocksApi.Services;
using StocksApi.ViewModels;

namespace StocksApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StocksController: ControllerBase
{
    private readonly IStockService _stockService;

    public StocksController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string code = "", string description = "")
    {
        var stocks = await _stockService.Get(code, description);
        if (!stocks.Any())
            return NotFound("Stocks not found");

        return Ok(stocks);
    }

    // [HttpPost]
    // public async Task<IActionResult> Create([FromBody] StockViewModelCreate stockViewModel)
    // {
    //
    //     return CreatedAtAction(nameof(Create), stockViewModel);�   
    // }
}