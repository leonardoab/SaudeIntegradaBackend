using AutoMapper;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;
using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Repository;
using System.Net.WebSockets;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Pessoa collection")]
    public class PessoaTest : IClassFixture<DependencyInjection>
    {
        private readonly IPessoaRepository _PessoaRepository;
        private readonly IContaRepository _ContaRepository;
        private readonly IPessoaService _PessoaService;
        private readonly IContaService _ContaService;
        private IMapper mapper;

        public PessoaTest(DependencyInjection dependencyInjection)
        {
            _ContaService = dependencyInjection.ServiceProvider.GetRequiredService<IContaService>();
            _PessoaService = dependencyInjection.ServiceProvider.GetRequiredService<IPessoaService>();
            _PessoaRepository = dependencyInjection.ServiceProvider.GetRequiredService<IPessoaRepository>();
            _ContaRepository = dependencyInjection.ServiceProvider.GetRequiredService<IContaRepository>();

        }

        [Fact]
        public void DeveCriarPessoaComSucesso()
        {
            var result = CriarPessoa();
            Assert.True(result is not null);
        }


        //to do
        [Fact]
        public async Task DeveEditar()
        {
            var listPessoa = _PessoaService.ObterTodos();
            var objPessoa = listPessoa.FirstOrDefault();

            PessoaDto pessoa = new PessoaDto()
            {
                Id = objPessoa.Id,
                Nome = "Teste Editar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                ContaId = objPessoa.ContaId
            };

            var result = _PessoaService.Editar(pessoa);
            Assert.True(result is not null);

        }


        //to do
        [Fact]
        public async Task DeveApagar()
        {
            var pessoa = new PessoaCriarDto()
            {
                Nome = "Teste Apagar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                ContaId = new Guid("3b950eb5-a533-4cb8-4792-08dc5983dd45")
            };

            var resultCriar = _PessoaService.Criar(pessoa);

            var result = _PessoaService.Apagar(resultCriar.Id);
            Assert.True(result is not null);
        }

        [Fact]
        public async Task DeveListaTodos()
        {
            var result = _PessoaService.ObterTodos();
            Assert.True(result is not null);
        }


        [Fact]
        public async Task DeveObterPessoaPorId()
        {
            var resultList = _PessoaService.ObterTodos();
            var objPessoa = resultList.FirstOrDefault();
            var result = _PessoaService.Obter(objPessoa.Id);
            Assert.True(result is not null);

        }

        public Pessoa CriarPessoa()
        {
            var conta = CriarConta();

            Pessoa pessoa = new Pessoa()
            {
                Nome = $"Pessoa {utils.RandomString(6)}",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                ContaId = conta.Id,
                Conta = conta,
                AvaliacaoFichas = new List<AvaliacaoFicha>()
            };
           
            this._PessoaRepository.Save(pessoa);
            return pessoa;
        }

        public Conta CriarConta()
        {
            Conta conta = new Conta()
            {
                Email = $"email_{utils.RandomString(4)}@gmail.com",
                Password = "123456",
                Telefone = $"{utils.RandomNumber(11)}",
                Apelido = $"apelido_{utils.RandomString(4)}",
                Ativo = true
            };

            this._ContaRepository.Save(conta);

            return conta;
        }

    }
}
