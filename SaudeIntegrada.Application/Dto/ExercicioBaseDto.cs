using SaudeIntegrada.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Dto
{
    public class ExercicioBaseDto 
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }

    public class ExercicioBaseCriarDto
    {
        
        [Required]
        public string Nome { get; set; }
    }
}
