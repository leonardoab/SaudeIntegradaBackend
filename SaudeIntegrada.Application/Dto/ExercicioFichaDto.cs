using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Dto
{
    public class ExercicioFichaDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Sets { get; set; } //4 series
        [Required]
        public string Repeticoes { get; set; } // 8 a 10 repeticoes
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string Carga { get; set; }
        [Required]
        public Guid IdExercicioBase { get; set; }
        
    }

    public class ExercicioFichaCriarDto
    {
        
        [Required]
        public string Sets { get; set; } //4 series
        [Required]
        public string Repeticoes { get; set; } // 8 a 10 repeticoes
        [Required]
        public string Observacoes { get; set; }
        [Required]
        public string Carga { get; set; }
        [Required]
        public Guid IdExercicioBase { get; set; }
        
    }

    public class FichaExercicioFichaDto
    {
        [Required]
        public Guid FichaId { get; set; }
        [Required]
        public Guid ExercicioFichaId { get; set; }

    }
}
