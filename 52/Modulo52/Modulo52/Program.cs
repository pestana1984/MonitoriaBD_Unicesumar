using Modulo52.Repositories;
using Modulo52.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IAirportRepository, AirportRepository>();
builder.Services.AddSingleton<IAirportService, AirportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
