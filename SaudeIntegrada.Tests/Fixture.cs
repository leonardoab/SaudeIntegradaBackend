using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Tests
{
    public class Fixture
    {
        public Fixture() {
            var serviceColletion = new ServiceCollection();

            serviceColletion.AddScoped<SaudeIntegradaContext>();
            serviceColletion.AddTransient<IPessoaService, PessoaService>();
            serviceColletion.AddTransient<IPessoaRepository, PessoaRepository>();

            ServiceProvider = serviceColletion.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
