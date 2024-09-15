using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CompraVenda.Produto.Infrastructure.Extensions
{
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost/");
                });
            });
            
            return services;
        }
    }
}