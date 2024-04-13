using Microsoft.AspNetCore.Connections.Features;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Pessoa collection")]
    public class PessoaTest : IClassFixture<DependencyInjection>
    {
        private readonly IPessoaService _PessoaService;
        private readonly IContaService _ContaService;

        public PessoaTest(DependencyInjection dependencyInjection)
        {
            _PessoaService = dependencyInjection.ServiceProvider.GetRequiredService<IPessoaService>();
            _ContaService = dependencyInjection.ServiceProvider.GetRequiredService<IContaService>();
        }

        [Fact]
        public void DeveCriarPessoaComSucesso()
        {
            //var resultList = _ContaService.ObterTodos();
            //var objConta = resultList.FirstOrDefault();

            PessoaCriarDto pessoa = new PessoaCriarDto()
            {
                Nome = $"Pessoa {utils.RandomString(6)}",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                ContaId =  new Guid("087ff101-60c8-4f06-d3a2-08dc5aa7fdec")
            };

            var result = _PessoaService.Criar(pessoa);
            Assert.True(result is not null);
        }


        //to do
        [Fact]
        public async Task DeveEditar()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = new Guid("cccb2dd5-814f-418c-ab29-80c74f970675"),
                Nome = "Teste Editar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                ContaId = new Guid("087ff101-60c8-4f06-d3a2-08dc5aa7fdec")
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
            var result =  _PessoaService.Obter(objPessoa.Id);
            Assert.True(result is not null);

        }
    }
}
