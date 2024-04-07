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
    public class AvaliacaoFichaService : IAvaliacaoFichaService
    {
        private readonly IAvaliacaoFichaRepository AvaliacaoFichaRepository;
        private readonly IMapper mapper;

        public AvaliacaoFichaService(IAvaliacaoFichaRepository AvaliacaoFichaRepository, IMapper mapper)
        {
            this.AvaliacaoFichaRepository = AvaliacaoFichaRepository;
            this.mapper = mapper;
        }

        public AvaliacaoFichaDto Criar(AvaliacaoFichaDto dto)
        {
            AvaliacaoFicha avaliacaoFicha = this.mapper.Map<AvaliacaoFicha>(dto);
            this.AvaliacaoFichaRepository.Save(avaliacaoFicha);

            return this.mapper.Map<AvaliacaoFichaDto>(avaliacaoFicha);
        }

        public AvaliacaoFichaDto Editar(AvaliacaoFichaDto dto)
        {
            AvaliacaoFicha avaliacaoFicha = this.mapper.Map<AvaliacaoFicha>(dto);
            this.AvaliacaoFichaRepository.Update(avaliacaoFicha);

            return this.mapper.Map<AvaliacaoFichaDto>(avaliacaoFicha);
        }

        public AvaliacaoFichaDto Apagar(AvaliacaoFichaDto dto)
        {
            AvaliacaoFicha avaliacaoFicha = this.mapper.Map<AvaliacaoFicha>(dto);
            this.AvaliacaoFichaRepository.Delete(avaliacaoFicha);

            return this.mapper.Map<AvaliacaoFichaDto>(avaliacaoFicha);
        }

        public AvaliacaoFichaDto Obter(Guid id)
        {
            var avaliacaoFicha = this.AvaliacaoFichaRepository.GetById(id);
            return this.mapper.Map<AvaliacaoFichaDto>(avaliacaoFicha);
        }

        public IEnumerable<AvaliacaoFichaDto> ObterTodos()
        {
            var avaliacaoFicha = this.AvaliacaoFichaRepository.GetAll();
            return this.mapper.Map<IEnumerable<AvaliacaoFichaDto>>(avaliacaoFicha);
        }




    }
}
