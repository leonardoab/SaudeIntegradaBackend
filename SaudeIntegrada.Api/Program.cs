using Microsoft.EntityFrameworkCore;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Profile;
using SaudeIntegrada.Application.Service;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*var connectionString = builder.Configuration.GetConnectionString("SaudeIntegradaConnection");

builder.Services.AddDbContext<SaudeIntegradaContext>(options =>
{
    // Defina a montagem de migrações correta aqui
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SaudeIntegrada.Api"));
});*/

builder.Services.AddDbContext<SaudeIntegradaContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("SaudeIntegradaConnection"), b => b.MigrationsAssembly("SaudeIntegrada.Api"));
});

builder.Services.AddAutoMapper(typeof(AvaliacaoFichaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ContaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ExercicioBaseProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ExercicioFichaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(FichaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PessoaProfile).Assembly);


//Repositories
builder.Services.AddScoped< IAvaliacaoFichaRepository, AvaliacaoFichaRepository >();
builder.Services.AddScoped<IContaRepository,ContaRepository>();
builder.Services.AddScoped<IExercicioBaseRepository,ExercicioBaseRepository>();
builder.Services.AddScoped<IExercicioFichaRepository,ExercicioFichaRepository>();
builder.Services.AddScoped<IFichaRepository,FichaRepository>();
builder.Services.AddScoped<IPessoaRepository,PessoaRepository>();


//Services
builder.Services.AddScoped<IAvaliacaoFichaService,AvaliacaoFichaService>();
builder.Services.AddScoped<IContaService,ContaService>();
builder.Services.AddScoped<IExercicioBaseService,ExercicioBaseService>();
builder.Services.AddScoped<IExercicioFichaService,ExercicioFichaService>();
builder.Services.AddScoped<IFichaService,FichaService>();
builder.Services.AddScoped<IPessoaService,PessoaService>();

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
