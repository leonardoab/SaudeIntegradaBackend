using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;

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

        [Fact]
        public async Task DeveCriarFichaComSucesso()
        {
            var ficha = new ExercicioFichaCriarDto()
            {   
                Observacoes = "Aluno cardíaco",
                Carga = "10",
                Repeticoes = "10",
                Sets = "3",
                IdExercicioBase = new Guid("0bb832a3-1a70-4dbe-872f-08dc5b6ef17a")
            };

            var result = _ExercicioFichaService.Criar(ficha);

            Assert.True(result is CreatedResult);
        }
    }
}
