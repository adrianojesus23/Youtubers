using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AppProfessores.Data;
using AppProfessores.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure middleware
ConfigureMiddleware(app);

app.Run();

// Method to configure services
void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    builder.Services.AddControllers();

    // Configure the connection string
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Register the DbContext with SQL Server
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Configure JSON serialization options
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });

    // Configure additional services
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();

    // Add support for CORS (Cross-Origin Resource Sharing)
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });
}

// Method to configure middleware
void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage(); // Add exception page for development
    }

    app.UseHttpsRedirection();

    // Apply CORS policy
    app.UseCors("AllowAll");
    app.UseAuthentication();
    app.UseAuthorization();

    // Logging middleware
    app.Use(async (context, next) =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Processing request for {Path}", context.Request.Path);
        await next();
    });

    // Map endpoints (if needed)
    // app.MapGet("/", () => "Hello World!");
}
