using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Dto
{
    public class ExercicioFichaDto
    {
        public Guid Id { get; set; }
        public string Sets { get; set; } //4 series
        public string Repeticoes { get; set; } // 8 a 10 repeticoes
        public string Observacoes { get; set; }
    }
}
