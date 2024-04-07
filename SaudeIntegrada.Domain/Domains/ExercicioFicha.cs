using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class ExercicioFicha : Entity<Guid>
    {
        public string Sets { get; set; } //4 series
        public string Repeticoes { get; set; } // 8 a 10 repeticoes
        public ExercicioBase ExercicioBase { get; set; }
        public string Observacoes { get; set; }


    }
}
