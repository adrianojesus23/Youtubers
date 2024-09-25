using BookStore.Infrastructure.Persistence;
using BookStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using System.Reflection;
using BookStore.Application.Books.Commands;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura Swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookStore API",
        Version = "v1",
        Description = "API for managing books in the bookstore",
        Contact = new OpenApiContact
        {
            Name = "BookStore Team",
            Email = "contact@bookstore.com"
        }
    });
});


// Registrar MediatR para lidar com comandos e consultas
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllBooksQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetBookByIdQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteBookCommandHandler).Assembly));

// Registra o repositório genérico e o Unit of Work
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper (se necessário, se houver mapeamentos de DTOs)
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Adiciona validação com FluentValidation e escaneia os validadores na camada Application
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Adiciona os controladores da API
builder.Services.AddControllers();


// Configuração do Swagger UI para testar a API
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

app.Run();
