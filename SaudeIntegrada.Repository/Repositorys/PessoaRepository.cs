﻿using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Repository.Repository
{
    public class PessoaRepository : Repository<Pessoa>
    {
        public PessoaRepository(SaudeIntegradaContext context) : base(context)
        {
        }
    }
}