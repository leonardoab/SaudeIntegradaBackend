using System;
using SaudeIntegrada.Domain.Domains;

namespace SaudeIntegrada.Application.Dto
{
	public class AvaliacaoFichaDto
	{
		public AvaliacaoFichaDto()
		{
			
		}
        public Guid Id { get; set; }
        public string VelocidadeExecucao { get; set; }
        public string Descanso { get; set; }
        public string Duracao { get; set; }
        public string DataTesteCarga { get; set; }
        public string DataProximoTesteCarga { get; set; }
        public string Observacoes { get; set; }
    }
}

