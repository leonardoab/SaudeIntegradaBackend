using SaudeIntegrada.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain
{
    public class Ficha : Entity<Guid>
    {
        public string Nome { get; set; }
        public virtual IList<ExercicioFicha> ExerciciosFicha { get; set; }

    }
}
