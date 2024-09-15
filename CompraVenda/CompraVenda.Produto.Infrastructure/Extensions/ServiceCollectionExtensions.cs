using CompraVenda.Produto.Domain.Interfaces;
using CompraVenda.Produto.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CompraVenda.Produto.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IProdutoRepository>(sp => new ProdutoRepository(connectionString));
        return services;
    }
}