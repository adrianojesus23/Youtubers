using ApiProduct.DTOs.Commands;
using ApiProduct.DTOs.Queries;
using ApiProduct.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProduct.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

     
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? code, 
                                    [FromQuery] string? description, 
                                    [FromQuery] decimal? minPreco, 
                                    [FromQuery] bool? isAvailable)
        {
            var result = _produtoService.GetAll(new GetAllProdutosQuery(code, description, minPreco, isAvailable));

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

      
        [HttpPost]
        public IActionResult Create([FromBody] CreateProdutoCommand command)
        {
            var result = _produtoService.Create(command);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

      
        [HttpPut]
        public IActionResult Update([FromBody] UpdateProdutoCommand command)
        {
            var result = _produtoService.Update(command);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var command = new GetByIdProdutoQuery(id);

            var result = _produtoService.GetById(command);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(new { Success = result.Value });
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteProdutoCommand deleteProduto)
        {
            var result = _produtoService.Delete(deleteProduto);

            if (!result.IsSuccess)
                return NotFound(result.Error);

            return Ok(new { Success = result.Value });
        }
    }

}
