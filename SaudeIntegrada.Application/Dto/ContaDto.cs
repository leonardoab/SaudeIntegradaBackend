using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Dto
{
    public class ContaDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Apelido { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }

    public class ContaLoginDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }

    public class ContaCriarDto
    {
        [Required]
        public string Apelido { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }


}
