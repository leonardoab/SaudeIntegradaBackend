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
    public class AvaliacaoFichaService : IAvaliacaoFichaService
    {
        private readonly IAvaliacaoFichaRepository AvaliacaoFichaRepository;
        private readonly IMapper mapper;

        public AvaliacaoFichaService(IAvaliacaoFichaRepository AvaliacaoFichaRepository, IMapper mapper)
        {
            this.AvaliacaoFichaRepository = AvaliacaoFichaRepository;
            this.mapper = mapper;
        }
    }
}
