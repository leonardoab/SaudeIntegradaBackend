using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Exercicio Base collection")]
    public class ExercicioBaseTest : IClassFixture<DependencyInjection>
    {
        private readonly IExercicioBaseService _ExercicioBaseService;

        public ExercicioBaseTest(DependencyInjection dependencyInjection)
        {
            _ExercicioBaseService = dependencyInjection.ServiceProvider.GetRequiredService<IExercicioBaseService>();
        }

        [Fact]
        public async Task DeveCriarExercicioComSucesso()
        {
            var listExercicios = new List<string> { 
                "Supino Reto",
                "Supino Inclinado",
                "Supino Declinado",
                "Crucifixo",
                "Desenvolvimento Arnold",
                "Crucifixo com Cabos",
                "Crucifixo Inclinado com Cabos",
                "Crucifixo Declinado com Cabos",
            };

            foreach (var item in listExercicios)
            {
                var exercicio = new ExercicioBaseCriarDto()
                {
                    Nome = item
                };

                var result = _ExercicioBaseService.Criar(exercicio);
                Assert.True(result is not null);
            }

        }

        [Fact]
        public async Task DeveEditarExercicioComSucesso()
        {
            var exercicio = new ExercicioBaseDto {
                Id = new Guid("0bb832a3-1a70-4dbe-872f-08dc5b6ef17a"),
                Nome = "Desenvolvimento com Halteres"
            };

            var result = _ExercicioBaseService.Editar(exercicio);
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveApagar()
        {
            var exercicio = new ExercicioBaseCriarDto()
            {
                Nome = "Supino Declinado"
            };

            var exercicioCriado = _ExercicioBaseService.Criar(exercicio);
            var result = _ExercicioBaseService.Apagar(exercicioCriado.Id);
            Assert.True(result is not null);
        }

        [Fact]
        public async Task DeveListaTodos()
        {
            var result = _ExercicioBaseService.ObterTodos();
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveObterExercicioPorId()
        {
            var resultList = _ExercicioBaseService.ObterTodos();
            var obj = resultList.FirstOrDefault();
            var result = _ExercicioBaseService.Obter(obj.Id);
            Assert.True(result is not null);
        }

    }
}
