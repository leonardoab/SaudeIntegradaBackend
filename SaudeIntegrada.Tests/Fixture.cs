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
    public class Fixture
    {
        public Fixture() {

            var program = new Program();

            var serviceColletion = new ServiceCollection();

            //var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=SaudeIntegradaDatabase";
            
            serviceColletion.AddDbContextFactory<SaudeIntegradaContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True; Initial Catalog=SaudeIntegradaDatabase", b => b.MigrationsAssembly("SaudeIntegrada.Api")));
            
            serviceColletion.AddAutoMapper(typeof(PessoaProfile).Assembly);

            serviceColletion.AddTransient<DbContext, SaudeIntegradaContext>();
            serviceColletion.AddTransient<IPessoaService, PessoaService>();
            serviceColletion.AddTransient<IPessoaRepository, PessoaRepository>();
            //serviceColletion.AddTransient<IMapper, Mapper>();

            ServiceProvider = serviceColletion.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
