using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class AvaliacaoFicha : Entity<Guid>
    {
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
        public string Objetivo {  get; set; }
        
        public Pessoa Pessoa { get; set; }
        public virtual IList<Ficha> Fichas { get; set; } 

    }
}
