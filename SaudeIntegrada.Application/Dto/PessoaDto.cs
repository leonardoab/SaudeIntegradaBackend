using System;
using System.ComponentModel.DataAnnotations;
namespace SaudeIntegrada.Application.Dto
{
	public class PessoaDto
	{
		public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Sexo { get; set; }

        
        public DateTime DataNascimento { get; set; } 
    }
}

