using AutoMapper;
using CompraVenda.Produto.Domain.Entities;
using CompraVenda.Produto.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompraVenda.Produto.Domain.DTOs;

namespace CompraVenda.Produto.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        
        

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
        }

        public async Task<ProdutoDto> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task AddAsync(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Domain.Entities.Produto>(produtoDto);
            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateAsync(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Domain.Entities.Produto>(produtoDto);
            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }
}