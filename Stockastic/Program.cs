using Stockastic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Stockastic.Services.Interfaces;
using Stockastic.Services;

var builder = WebApplication.CreateBuilder(args);

/* Injecao de servicos */

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("StockasticContext");

builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy",
                          policy =>
                          {
                              policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                                                 
                          });
});

builder.Services.AddDbContext<StockasticContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();