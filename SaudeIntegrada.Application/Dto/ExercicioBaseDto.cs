using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Dto
{
    public class ExercicioBaseDto 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
