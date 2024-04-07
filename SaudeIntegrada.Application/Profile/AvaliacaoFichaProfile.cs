using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Profile
{
    public class AvaliacaoFichaProfile : AutoMapper.Profile
    {
        public AvaliacaoFichaProfile()
        {
            CreateMap<AvaliacaoFichaDto, AvaliacaoFicha>();
            CreateMap<AvaliacaoFicha, AvaliacaoFichaDto>();

        }
    }
}
