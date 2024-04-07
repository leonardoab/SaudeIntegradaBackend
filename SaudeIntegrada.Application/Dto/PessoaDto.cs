using System;
namespace SaudeIntegrada.Application.Dto
{
	public class PessoaDto
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }

        
        public DateTime DataNascimento { get; set; } 
    }
}

