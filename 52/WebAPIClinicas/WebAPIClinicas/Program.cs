using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Configuration;
using WebAPIClinicas.Data;
using WebAPIClinicas.Models;
using WebAPIClinicas.Repositories;
using WebAPIClinicas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConection")));

builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<EnderecoRepository>();

var configuration = builder.Configuration;

builder.Services.AddScoped<NpgsqlConnection>(sp =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
