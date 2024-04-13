using Microsoft.Extensions.DependencyInjection;
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
    [Collection("Ficha collection")]
    public class FichaTest : IClassFixture<DependencyInjection>
    {
        private readonly IFichaService _FichaService;

        public FichaTest(DependencyInjection dependencyInjection)
        {
            _FichaService = dependencyInjection.ServiceProvider.GetRequiredService<IFichaService>();
        }

        [Fact]
        public async Task DeveCriarExercicioComSucesso()
        {
            var listFichas = new List<string> {
                "Ficha 1",
                "Ficha 2",
                "Ficha 3",
                "Ficha 4",
                "Ficha 5",
                "Ficha 6"
            };

            foreach (var item in listFichas)
            {
                var ficha = new FichaCriarDto()
                {
                    Nome = item
                };

                var result = _FichaService.Criar(ficha);
                Assert.True(result is not null);
            }

        }

        [Fact]
        public async Task DeveEditarExercicioComSucesso()
        {
            var ficha = new FichaDto
            {
                Id = new Guid("4a0fe678-c671-48b1-8a35-08dc5b7073fe"),
                Nome = "Ficha Editada"
            };

            var result = _FichaService.Editar(ficha);
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveApagar()
        {
            var ficha = new FichaCriarDto()
            {
                Nome = "Ficha a ser apagada"
            };

            var exercicioCriado = _FichaService.Criar(ficha);
            var result = _FichaService.Apagar(exercicioCriado.Id);
            Assert.True(result is not null);
        }

        [Fact]
        public async Task DeveListaTodos()
        {
            var result = _FichaService.ObterTodos();
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveObterExercicioPorId()
        {
            var resultList = _FichaService.ObterTodos();
            var obj = resultList.FirstOrDefault();
            var result = _FichaService.Obter(obj.Id);
            Assert.True(result is not null);
        }
    }
}
