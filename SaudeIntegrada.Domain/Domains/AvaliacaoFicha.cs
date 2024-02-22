using SaudeIntegrada.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class AvaliacaoFicha : Entity<Guid>
    {
        public Pessoa Pessoa { get; set; }
        public string VelocidadeExecucao { get; set; }
        public string Descanso { get; set; }
        public string Duracao { get; set; }
        public DateTime DataTesteCarga { get; set; }
        public DateTime DataProximoTesteCarga { get; set; }
        public string Observacoes { get; set; }
        public virtual IList<Ficha> Fichas { get; set; }
    }
}
