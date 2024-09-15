using CompraVenda.Produto.Aplication;
using CompraVenda.Produto.Application;
using CompraVenda.Produto.Application.Services;
using CompraVenda.Produto.Domain.Entities;
using CompraVenda.Produto.Infrastructure;
using CompraVenda.Produto.Infrastructure.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog para logging estruturado
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

// Adiciona serviços de aplicação e infraestrutura
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransitServices();
// Configuração do cliente HTTP com Polly
//builder.Services.AddHttpClient("ProdutoClient")
//    .AddTransientHttpErrorPolicy(policyBuilder =>
//        policyBuilder.WaitAndRetryAsync(
//            retryCount: 3, // Número de tentativas
//            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Intervalo exponencial
//            onRetry: (outcome, timespan, retryAttempt, context) =>
//            {
//                // Log ou ação durante o retry
//                Console.WriteLine($"Tentativa {retryAttempt} falhou. Esperando {timespan.TotalSeconds} segundos antes da próxima tentativa.");
//            }
//        )
//    );

builder.Services.AddHttpClient("ProdutoClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5097"); // URL base para o serviço de produtos
})
.AddTransientHttpErrorPolicy(policyBuilder =>
    policyBuilder.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)) // Tenta novamente até 3 vezes com intervalo de 2 segundos
)
.AddTransientHttpErrorPolicy(policyBuilder =>
    policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)) // Abre o circuito após 5 falhas e mantém aberto por 30 segundos
);

// Adiciona serviços de autorização
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// builder.Services.AddMediatR(typeof(Program).Assembly); 
// // Assumindo que os handlers estão no mesmo assembly
//
// // Configura MediatR apontando para o assembly de Application
// builder.Services.AddMediatR(cfg => 
//     cfg.RegisterServicesFromAssembly(typeof(CreateProdutoCommand).Assembly)); 
// // Configura MediatR
// // Passa o assembly onde os handlers estão localizados
// builder.Services.AddMediatR(cfg => 
//     cfg.RegisterServicesFromAssembly(typeof(CreateProdutoCommandHandler).Assembly));

//dotnet run --project path/to/CompraVenda.ApiGateway
//dotnet run --project path/to/CompraVenda.Produto.API
/**
 Verificação
API Gateway: Verifique se o API Gateway está rodando acessando o endpoint configurado para o Ocelot (geralmente algo como http://localhost:5000 ou http://localhost:5001).
Serviço de Produtos: Teste se o serviço de produtos está acessível através do API Gateway. Por exemplo, faça uma requisição para http://localhost:5000/api/produtos (ajuste o endpoint conforme sua configuração).
 */

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();