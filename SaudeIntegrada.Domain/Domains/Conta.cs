using SaudeIntegrada.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Domain.Domains
{
    public class Conta : Entity<Guid>
    {
        public Pessoa Pessoa { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


    }
}
