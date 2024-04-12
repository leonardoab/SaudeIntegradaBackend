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

            var conta = new ContaCriarDto()
            {
                Email = $"pessoa_{utils.RandomString(6)}@teste.com",
                Password = "123456",
                Apelido = $"pessoa_{utils.RandomString(6)}",
                Telefone = utils.RandomNumber(10)
            };

            var objConta = _ContaService.Criar(conta);

            var pessoa = new PessoaCriarDto()
            {
                Nome = $"Pessoa {utils.RandomString(6)}",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = utils.RandomNumber(10),
                IdConta = objConta.Id
            };

            var result = _PessoaService.Criar(pessoa);
            Assert.True(result is not null);
            
            var guidOutput = Guid.Empty;
            var blnDelete = Guid.TryParse(result.Id.ToString(), out guidOutput);   
            if(blnDelete)
                _PessoaService.Apagar(result.Id);
        }

        [Fact]
        public async Task DeveEditar()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = new Guid("3b950eb5-a533-4cb8-4792-08dc5983dd45"),
                Nome = "Teste Editar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21988665544"
            };

            var result = _PessoaService.Editar(pessoa);
            Assert.True(result is not null);
            
            var guidOutput = Guid.Empty;
            var blnDelete = Guid.TryParse(result.Id.ToString(), out guidOutput);
            if (blnDelete)
                _PessoaService.Apagar(result.Id);
        }


        [Fact]
        public async Task DeveApagar()
        {
            var pessoa = new PessoaCriarDto()
            {
                Nome = "Teste Apagar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21988665544"
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
