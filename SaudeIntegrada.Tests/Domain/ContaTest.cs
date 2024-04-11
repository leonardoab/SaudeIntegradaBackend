using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Api.Controllers;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Conta collection")]
    public class ContaTest : IClassFixture<DependencyInjection>
    {
        private readonly IContaService _ContaService;

        public ContaTest(DependencyInjection dependencyInjection)
        {
            _ContaService = dependencyInjection.ServiceProvider.GetRequiredService<IContaService>();
        }

        [Fact]
        public async Task DeveCriarContaComSucesso()
        {
            var conta = new ContaDto()
            {
                Email = "teste@teste.com",
                Password = "123456",
                Apelido = "teste",
                Telefone = "21988665544"
            };

            var controller = new ContaController(_ContaService);
            var result = controller.Criar(conta);

            Assert.True(result is CreatedResult);
        }

        [Fact]
        public async Task NaoDeveCriarContaSemRequest()
        {
            var conta = new ContaDto();

            var controller = new ContaController(_ContaService);
            var result = controller.Criar(conta);

            Assert.True(result is BadRequestObjectResult);
        }

        [Fact]
        public void ListaTodos()
        {
            var controller = new ContaController(_ContaService);
            var result = controller.ListaTodos();
            var statusCode = (result as OkObjectResult).StatusCode;
            //var res = (result as OkObjectResult).Value as IEnumerable<ContaDto>;

            Assert.True(statusCode.Equals(200));
        }


        [Fact]
        public void ContaNaoEncontrada()
        {
            var id = new Guid("96dde085-f7d2-4997-24cc-08dc58fbaf86");

            var controller = new ContaController(_ContaService);
            var result = controller.GetContasPorId(id);
            //var res = (result as OkObjectResult).Value as ContaDto;
            int? statusCode = ((IStatusCodeActionResult)result).StatusCode;
            Assert.True(statusCode.Equals(404));

        }


    }
}
