using Microsoft.EntityFrameworkCore;
using SaudeIntegrada.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("SaudeIntegradaConnection");

builder.Services.AddDbContext<SaudeIntegradaContext>(options =>
{
    // Defina a montagem de migrações correta aqui
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SaudeIntegrada.Api"));
});


var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
