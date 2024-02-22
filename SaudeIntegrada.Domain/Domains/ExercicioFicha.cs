using SaudeIntegrada.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class ExercicioFicha : Entity<Guid>
    {
        public string Sets { get; set; }
        public string Repeticoes { get; set; }
        public ExercicioBase ExercicioBase { get; set; }


    }
}
