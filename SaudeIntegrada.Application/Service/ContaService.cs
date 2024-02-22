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
    public class ContaService : IContaService
    {
        private readonly IContaRepository ContaRepository;
        private readonly IMapper mapper;

        public ContaService(IContaRepository contaRepository, IMapper mapper)
        {
            ContaRepository = contaRepository;
            this.mapper = mapper;
        }
    }
}
