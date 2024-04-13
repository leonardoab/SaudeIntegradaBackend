using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class Ficha : Entity<Guid>
    {
        public string Nome { get; set; }
        public virtual IList<ExercicioFicha> ExerciciosFicha { get; set; } = new List<ExercicioFicha>();

    }
}
