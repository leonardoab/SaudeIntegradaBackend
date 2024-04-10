using Microsoft.Extensions.DependencyInjection;
using SaudeIntegrada.Api.Controllers;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Application.Service;
using System.Net;
using Xunit;

namespace SaudeIntegrada.Tests.Domain
{
    [Collection("Pessoa collection")]
    public class PessoaTest   
    {
        private readonly IPessoaService _PessoaService;

        //public PessoaTest(Fixture fixture)
        //{
        //    _PessoaService = fixture.ServiceProvider.GetRequiredService<IPessoaService>();
        //}

        public PessoaTest(IPessoaService _PessoaService)
        {
                this._PessoaService = _PessoaService;
        }

        [Fact]
        public async Task DeveCriarPessoaComSucesso()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = Guid.NewGuid(),
                Nome = "João",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21 98559-9988"
            };
            
            var controller = new PessoaController(_PessoaService);
            var result = controller.Criar(pessoa);

            Assert.True(result.ToString().Equals(HttpStatusCode.OK));

        }

        [Fact]
        public void DeveEditarComSucesso()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = new Guid("96dde085-f7d2-4997-24cc-08dc58fbaf86"),
                Nome = "João",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21 98559-9988",
            };

            var controller = new PessoaController(_PessoaService);
            var result = controller.Editar(pessoa);

            Assert.True(result.ToString().Equals(HttpStatusCode.OK));

        }


        [Fact]
        public void DeveExcluirComSucesso()
        {
            PessoaDto pessoa = new PessoaDto()
            {
                Id = new Guid("96dde085-f7d2-4997-24cc-08dc58fbaf86"),
                Nome = "João",
                DataNascimento = DateTime.Now,
                Sexo = "M",
                Telefone = "21 98559-9988",
            };

            var controller = new PessoaController(_PessoaService);
            var result = controller.Apagar(pessoa);

            Assert.True(result.ToString().Equals(HttpStatusCode.OK));

        }

        [Fact]
        public void ListaTodos()
        {
            var controller = new PessoaController(_PessoaService);
            var result = controller.ListaTodos();

            Assert.True(result.ToString().Equals(HttpStatusCode.OK));

        }


        [Fact]
        public void DeveObterPessoaPorId()
        {
            var id = new Guid("96dde085-f7d2-4997-24cc-08dc58fbaf86");

            var controller = new PessoaController(_PessoaService);
            var result = controller.GetPessoasPorId(id);

            Assert.True(result.ToString().Equals(HttpStatusCode.OK));

        }
    }
}
