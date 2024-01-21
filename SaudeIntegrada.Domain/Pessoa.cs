using SaudeIntegrada.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain
{
    public class Pessoa : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual IList<AvaliacaoFicha> AvaliacaoFichas { get; set; }
    }
}
