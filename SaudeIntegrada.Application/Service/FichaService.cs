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

        public FichaService(IFichaRepository FichaRepository, IMapper mapper)
        {
            this.FichaRepository = FichaRepository;
            this.mapper = mapper;
        }

        public FichaDto Criar(FichaDto dto)
        {
            Ficha ficha = this.mapper.Map<Ficha>(dto);
            this.FichaRepository.Save(ficha);

            return this.mapper.Map<FichaDto>(ficha);
        }

        public FichaDto Editar(FichaDto dto)
        {
            Ficha ficha = this.mapper.Map<Ficha>(dto);
            this.FichaRepository.Update(ficha);

            return this.mapper.Map<FichaDto>(ficha);
        }

        public FichaDto Apagar(FichaDto dto)
        {
            Ficha ficha = this.mapper.Map<Ficha>(dto);
            this.FichaRepository.Delete(ficha);

            return this.mapper.Map<FichaDto>(ficha);
        }

        public FichaDto Obter(Guid id)
        {
            var ficha = this.FichaRepository.GetById(id);
            return this.mapper.Map<FichaDto>(ficha);
        }

        public IEnumerable<FichaDto> ObterTodos()
        {
            var ficha = this.FichaRepository.GetAll();
            return this.mapper.Map<IEnumerable<FichaDto>>(ficha);
        }


    }
}
