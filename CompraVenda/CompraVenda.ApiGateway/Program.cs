using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);



// Adiciona Ocelot e Swagger
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Para produção, você pode adicionar uma configuração extra de segurança no Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilita redirecionamento de HTTPS
app.UseHttpsRedirection();

await app.UseOcelot();
// Executa a aplicação
app.Run();

