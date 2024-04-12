using System;
using System.ComponentModel.DataAnnotations;
namespace SaudeIntegrada.Application.Dto
{
    public class PessoaDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }       
        [Required]
        public string Sexo { get; set; }
        [Required]
        public Guid ContaId { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }

    public class PessoaCriarDto
    {
        
        [Required]
        public string Nome { get; set; }        
        [Required]
        public string Sexo { get; set; }
        [Required]
        public Guid ContaId { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}

