using System;
using System.ComponentModel.DataAnnotations;
namespace SaudeIntegrada.Application.Dto
{
	public class FichaDto
	{
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid IdAvaliacaoFicha { get; set; }
    }

    public class FichaCriarDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid IdAvaliacaoFicha { get; set; }
    }
}

