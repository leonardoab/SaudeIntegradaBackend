using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Domain.Domains;

namespace SaudeIntegrada.Application.Profile
{
    public class FichaProfile : AutoMapper.Profile
    {
        public FichaProfile()
        {
            CreateMap<FichaDto, Ficha>();
            CreateMap<Ficha, FichaDto>();

        }
    }
}
