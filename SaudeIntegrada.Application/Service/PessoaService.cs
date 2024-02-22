using AutoMapper;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository PessoaRepository;
        private readonly IMapper mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            PessoaRepository = pessoaRepository;
            this.mapper = mapper;
        }
    }
}
