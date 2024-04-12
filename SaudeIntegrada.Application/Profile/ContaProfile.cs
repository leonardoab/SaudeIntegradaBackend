using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Domain.Domains;

namespace SaudeIntegrada.Application.Profile
{
    public class ContaProfile : AutoMapper.Profile
    {
        public ContaProfile()
        {
            CreateMap<ContaDto, Conta>();
            CreateMap<Conta, ContaDto>();
            CreateMap<ContaCriarDto, Conta>();

        }
    }
}
