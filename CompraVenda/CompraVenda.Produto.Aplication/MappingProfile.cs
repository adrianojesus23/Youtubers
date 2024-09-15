using AutoMapper;
using CompraVenda.Produto.Domain.DTOs;

namespace CompraVenda.Produto.Aplication;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Produto, ProdutoDto>().ReverseMap();
    }
}