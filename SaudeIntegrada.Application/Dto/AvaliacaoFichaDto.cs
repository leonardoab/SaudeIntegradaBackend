using System;
using SaudeIntegrada.Domain.Entity;
using SaudeIntegrada.Domain.Domains;
using System.ComponentModel.DataAnnotations;

namespace SaudeIntegrada.Application.Dto
{
	public class AvaliacaoFichaDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime DataTesteCarga { get; set; }
        [Required]
        public DateTime DataProximoTesteCarga { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        public string Nivel { get; set; }
        [Required]
        public string Metodo { get; set; }
        [Required]
        public string VelocidadeExecucao { get; set; }
        [Required]
        public string Descanso { get; set; }
        [Required]
        public string Duracao { get; set; }
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string ZonaQueima { get; set; }
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public Guid IdPessoa { get; set; }
    }

    public class AvaliacaoFichaCriarDto
    {
        [Required]
        public DateTime DataTesteCarga { get; set; }
        [Required]
        public DateTime DataProximoTesteCarga { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        public string Nivel { get; set; }
        [Required]
        public string Metodo { get; set; }
        [Required]
        public string VelocidadeExecucao { get; set; }
        [Required]
        public string Descanso { get; set; }
        [Required]
        public string Duracao { get; set; }
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string ZonaQueima { get; set; }
        [Required]
        public string Objetivo { get; set; }
        [Required]
        public Guid IdPessoa { get; set; }
    }
}

