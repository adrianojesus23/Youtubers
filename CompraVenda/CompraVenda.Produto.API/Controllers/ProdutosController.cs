using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompraVenda.Produto.Domain.DTOs;
using CompraVenda.Produto.Domain.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace CompraVenda.Produto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProdutosController(IProdutoService produtoService, IHttpClientFactory httpClientFactory)
        {
            _produtoService = produtoService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> GetById(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            if (produto == null)
            {
                try
                {
                    produto = await GetProdutoAsync(id); // Fallback para o método GetProdutoAsync
                    if (produto == null)
                    {
                        return NotFound(); // Retorna 404 se o produto não for encontrado
                    }
                    return Ok(produto); // Retorna 200 OK com o produto
                }
                catch (Exception ex)
                {
                    // Registre o erro e retorne uma resposta adequada
                    // Exemplo de registro do erro:
                    // _logger.LogError(ex, "Erro ao buscar o produto no fallback.");
                    return StatusCode(500, "Erro interno ao buscar o produto."); // Retorna 500 se algo der errado no fallback
                }
            }

            return Ok(produto); // Retorna 200 OK com o produto se encontrado pelo serviço primário
        }

        private async Task<ProdutoDto> GetProdutoAsync(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ProdutoClient");

            var response = await httpClient.GetAsync($"/api/produtos/1");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProdutoDto>(content);
        }
    


    [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAll()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

    

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProdutoDto produtoDto, [FromQuery] int id)
        {
            await _produtoService.AddAsync(produtoDto);
            return CreatedAtAction(nameof(GetById), new { id = id }, produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProdutoDto produtoDto)
        {
            if (id > 0)
            {
                return BadRequest();
            }
            await _produtoService.UpdateAsync(produtoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }
    }
}