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
using SaudeIntegrada.Repository.Repository;

namespace SaudeIntegrada.Application.Service
{
    public class FichaService : IFichaService
    {
        private readonly IFichaRepository FichaRepository;
        private readonly IMapper mapper;
        private readonly IAvaliacaoFichaRepository AvaliacaoFichaRepository;

        public FichaService(IFichaRepository FichaRepository, IMapper mapper, IAvaliacaoFichaRepository AvaliacaoFichaRepository)
        {
            this.FichaRepository = FichaRepository;
            this.mapper = mapper;
            this.AvaliacaoFichaRepository = AvaliacaoFichaRepository;
        }

        public FichaDto Criar(FichaCriarDto dto)
        {
            Ficha ficha = this.mapper.Map<Ficha>(dto);

            //AvaliacaoFicha avaliacaoFicha = AvaliacaoFichaRepository.GetById(dto.IdAvaliacaoFicha);

            //ficha.ava

            this.FichaRepository.Save(ficha);

            return this.mapper.Map<FichaDto>(ficha);
        }

        public FichaDto Editar(FichaDto dto)
        {
            Ficha ficha = this.mapper.Map<Ficha>(dto);
            this.FichaRepository.Update(ficha);

            return this.mapper.Map<FichaDto>(ficha);
        }

        public FichaDto Apagar(Guid id)
        {
            Ficha ficha = this.FichaRepository.GetById(id);

            if (!this.FichaRepository.Exists(x => x.Id == id)) { throw new Exception("Ficha nao existe"); }

            
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

        public IEnumerable<FichaDto> BuscarPorParteNome(string partenome)
        {
            var listaFichas = FichaRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (IEnumerable<FichaDto>)listaFichas;

        }


    }
}
