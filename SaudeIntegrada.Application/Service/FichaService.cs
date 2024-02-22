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
    public class FichaService : IFichaService
    {
        private readonly IFichaRepository FichaRepository;
        private readonly IMapper mapper;

        public FichaService(IFichaRepository fichaRepository, IMapper mapper)
        {
            FichaRepository = fichaRepository;
            this.mapper = mapper;
        }
    }
}
