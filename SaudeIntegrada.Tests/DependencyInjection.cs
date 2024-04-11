using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Profile;
using SaudeIntegrada.Application.Service;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.Repository;

namespace SaudeIntegrada.Tests
{
    public class DependencyInjection
    {
        public DependencyInjection() {

            var program = new Program();

            var serviceColletion = new ServiceCollection();

            //var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=SaudeIntegradaDatabase";
            
            serviceColletion.AddDbContext<SaudeIntegradaContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=SaudeIntegradaDatabase", b => b.MigrationsAssembly("SaudeIntegrada.Api")));
            
            serviceColletion.AddAutoMapper(typeof(AvaliacaoFichaProfile).Assembly);
            serviceColletion.AddAutoMapper(typeof(ContaProfile).Assembly);
            serviceColletion.AddAutoMapper(typeof(ExercicioBaseProfile).Assembly);
            serviceColletion.AddAutoMapper(typeof(ExercicioFichaProfile).Assembly);
            serviceColletion.AddAutoMapper(typeof(FichaProfile).Assembly);
            serviceColletion.AddAutoMapper(typeof(PessoaProfile).Assembly);

            serviceColletion.AddTransient<DbContext, SaudeIntegradaContext>();
            
            //Services
            serviceColletion.AddTransient<IAvaliacaoFichaService, AvaliacaoFichaService>();
            serviceColletion.AddTransient<IContaService, ContaService>();
            serviceColletion.AddTransient<IExercicioBaseService, ExercicioBaseService>();
            serviceColletion.AddTransient<IExercicioFichaService, ExercicioFichaService>();
            serviceColletion.AddTransient<IFichaService, FichaService>();
            serviceColletion.AddTransient<IPessoaService, PessoaService>();


            //Repositories
            serviceColletion.AddTransient<IAvaliacaoFichaRepository, AvaliacaoFichaRepository>();
            serviceColletion.AddTransient<IContaRepository, ContaRepository>();
            serviceColletion.AddTransient<IExercicioBaseRepository, ExercicioBaseRepository>();
            serviceColletion.AddTransient<IExercicioFichaRepository, ExercicioFichaRepository>();
            serviceColletion.AddTransient<IFichaRepository, FichaRepository>();
            serviceColletion.AddTransient<IPessoaRepository, PessoaRepository>();
            
            //serviceColletion.AddTransient<IMapper, Mapper>();

            ServiceProvider = serviceColletion.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
