using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Domain.Domains;
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

        public FichaDto Criar(FichaDto dto)
        {
            Ficha Ficha = this.mapper.Map<Ficha>(dto);
            this.FichaRepository.Save(Ficha);

            return this.mapper.Map<FichaDto>(Ficha);
        }

        public FichaDto Obter(Guid id)
        {
            var Ficha = this.FichaRepository.Get(id);
            return this.mapper.Map<FichaDto>(Ficha);
        }

        public IEnumerable<FichaDto> ObterTodos()
        {
            var Ficha = this.FichaRepository.GetAll();
            return this.mapper.Map<IEnumerable<FichaDto>>(Ficha);
        }

    }
}
