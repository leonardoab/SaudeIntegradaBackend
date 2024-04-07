using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class Pessoa : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Conta Conta { get; set; }

        public virtual IList<AvaliacaoFicha> AvaliacaoFichas { get; set; }

    }
}
