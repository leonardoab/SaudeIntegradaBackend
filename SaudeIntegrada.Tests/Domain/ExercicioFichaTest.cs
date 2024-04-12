using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Api.Controllers;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Exercicio collection")]
    public class ExercicioFichaTest : IClassFixture<DependencyInjection>
    {
        private readonly IExercicioFichaService _ExercicioFichaService;

        public ExercicioFichaTest(DependencyInjection dependencyInjection)
        {
            _ExercicioFichaService = dependencyInjection.ServiceProvider.GetRequiredService<IExercicioFichaService>();
        }

        //[Fact]
        //public async Task DeveCriarFichaComSucesso()
        //{
        //    var ficha = new ExercicioFichaDto()
        //    {
        //    };

        //    var controller = new ExercicioFichaController(_ExercicioFichaService);
        //    var result = controller.Criar(ficha);

        //    Assert.True(result is CreatedResult);
        //}
    }
}
