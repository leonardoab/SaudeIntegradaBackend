using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Ficha collection")]
    public class FichaTest : IClassFixture<DependencyInjection>
    {
        private readonly IFichaService _FichaService;

        public FichaTest(DependencyInjection dependencyInjection)
        {
            _FichaService = dependencyInjection.ServiceProvider.GetRequiredService<IFichaService>();
        }
    }
}
