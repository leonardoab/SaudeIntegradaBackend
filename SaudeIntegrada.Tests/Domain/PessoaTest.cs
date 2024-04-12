using Microsoft.AspNetCore.Connections.Features;
using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Pessoa collection")]
    public class PessoaTest : IClassFixture<DependencyInjection>
    {
        private readonly IPessoaService _PessoaService;

        public PessoaTest(DependencyInjection dependencyInjection)
        {
            _PessoaService = dependencyInjection.ServiceProvider.GetRequiredService<IPessoaService>();
        }

        [Fact]
        public async Task DeveCriarPessoaComSucesso()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Nome = "Teste Criar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21988665544"
            };

            var result = _PessoaService.Criar(pessoa);
            Assert.True(result is not null);
            
            var guidOutput = Guid.Empty;
            var blnDelete = Guid.TryParse(result.Id.ToString(), out guidOutput);   
            if(blnDelete)
                _PessoaService.Apagar(result);
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
                _PessoaService.Apagar(result);
        }


        [Fact]
        public async Task DeveApagar()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = new Guid("e50734bc-947b-4bc7-c7e3-08dc5a911117"),
                Nome = "Teste Criar",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21988665544"
            };
            var result = _PessoaService.Apagar(pessoa);
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
