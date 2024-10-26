using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StocksApi.DbContexts;
using StocksApi.Models;
using StocksApi.Repositories;
using StocksApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()  
    .AddEntityFrameworkStores<ApplicationDbContext>()  
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockService, StockService>();

// Configuração do JWT  
builder.Services.AddAuthentication(options =>  
{  
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
})    .AddJwtBearer(options =>  
{  
    options.TokenValidationParameters = new TokenValidationParameters  
    {  
        ValidateIssuer = true,  
        ValidateAudience = true,  
        ValidateLifetime = true,  
        ValidateIssuerSigningKey = true,  
        ValidIssuer = builder.Configuration["Jwt:Issuer"],  
        ValidAudience = builder.Configuration["Jwt:Audience"],  
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))  
    };    });  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>  
{  
    c.SwaggerDoc("v1", new() { Title = "Stock API", Version = "v1" });  
    // Adiciona suporte para JWT no Swagger  
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme  
    {  
        In = ParameterLocation.Header,  
        Description = "Insira o token JWT no formato **Bearer {token}**",  
        Name = "Authorization",  
        Type = SecuritySchemeType.Http,  
        Scheme = "bearer"  
    });  
  
    c.AddSecurityRequirement(new OpenApiSecurityRequirement  
    {  
    {            new OpenApiSecurityScheme  
        {  
            Reference = new OpenApiReference  
            {  
                Type = ReferenceType.SecurityScheme,  
                Id = "Bearer"  
            }  
        },            new string[] {}  
    }    });});  
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
