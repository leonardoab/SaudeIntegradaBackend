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
            var conta = new ContaCriarDto()
            {
                Email = $"criar_{utils.RandomString(6)}@teste.com",
                Password = "123456",
                Apelido = $"conta_{utils.RandomString(6)}",
                Telefone = utils.RandomNumber(11)
            };

            var result = _ContaService.Criar(conta);
            Assert.True(result is not null);
        }

        [Fact]
        public async Task DeveEditar()
        {
            var request = new ContaDto()
            {
                Email = $"editadorconta_{utils.RandomString(6)}@teste.com",
                Password = "123456",
                Apelido = $"conta_{utils.RandomString(6)}",
                Telefone = utils.RandomNumber(11),
                Id = new Guid("087ff101-60c8-4f06-d3a2-08dc5aa7fdec")
            };

            var result = _ContaService.Editar(request);
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveApagar()
        {
            var conta = new ContaCriarDto()
            {
                Email = $"apagarconta_{utils.RandomString(6)}@teste.com",
                Password = "123456",
                Apelido = $"conta_{utils.RandomString(6)}",
                Telefone = utils.RandomNumber(11)
            };

            var contaCriada = _ContaService.Criar(conta);
            var result = _ContaService.Apagar(contaCriada.Id);
            Assert.True(result is not null);
        }

        [Fact]
        public async Task DeveListaTodos()
        {
            var result = _ContaService.ObterTodos();
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveObterContaPorId()
        {
            var resultList = _ContaService.ObterTodos();
            var objConta = resultList.FirstOrDefault();
            var result = _ContaService.Obter(objConta.Id);
            Assert.True(result is not null);
        }


    }
}
