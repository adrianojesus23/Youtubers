using ApiProduct.DTOs;
using ApiProduct.DTOs.Commands;
using ApiProduct.DTOs.Handles;
using ApiProduct.DTOs.Queries;
using ApiProduct.Models;
using ApiProduct.Repositories;
using ApiProduct.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositório simulado com Bogus
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();

// Handlers com Result Pattern
builder.Services.AddScoped<IHandler<CreateProdutoCommand, Result<Produto>>, CreateProdutoHandler>();
builder.Services.AddScoped<IHandler<UpdateProdutoCommand, Result<Produto>>, UpdateProdutoHandler>(); 
builder.Services.AddScoped<IHandler<GetAllProdutosQuery, Result<IEnumerable<Produto>>>, GetAllProdutosHandler>();
builder.Services.AddScoped<IHandler<GetByIdProdutoQuery, Result<Produto>>, GetByIdProdutoHandler>();
builder.Services.AddScoped<IHandler<DeleteProdutoCommand, Result<bool>>, DeleteProdutoHandler>();  // Handler para Delete
// Serviço do Produto
builder.Services.AddScoped<IProdutoService,ProdutoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
