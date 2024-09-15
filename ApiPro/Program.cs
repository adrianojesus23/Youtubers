
using ApiPro.Data;
using ApiPro.Features.Professores.Configs;
using ApiPro.Features.Professores.Repositories;
using ApiPro.Features.Professores.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Configurar a string de conexão usando o padrão Options
            builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));
// Adicionando JsonSerializerOptions com ReferenceHandler.Preserve
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
// Registrar DbContext como Singleton
            builder.Services.AddDbContext<ProfessorContext>(options =>
            {
                var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Singleton);
            builder.Services.AddScoped<IProfessorService, ProfessorService>();
            builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
          

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
        }
    }
}
