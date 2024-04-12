using System;
using SaudeIntegrada.Domain.Entity;
using SaudeIntegrada.Domain.Domains;

namespace SaudeIntegrada.Application.Dto
{
	public class AvaliacaoFichaDto
    {
        public Guid Id { get; set; }
        public DateTime DataTesteCarga { get; set; }
        public DateTime DataProximoTesteCarga { get; set; }
        public DateTime DataCriacao { get; set; }

        public string Nivel { get; set; }
        public string Metodo { get; set; }
        public string VelocidadeExecucao { get; set; }
        public string Descanso { get; set; }
        public string Duracao { get; set; }
        public string Observacoes { get; set; }
        public string ZonaQueima { get; set; }
        public string Objetivo { get; set; }
    }
}

