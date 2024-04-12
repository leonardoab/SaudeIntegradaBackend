using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Service
{
    public class ExercicioBaseService : IExercicioBaseService
    {
        private readonly IExercicioBaseRepository ExercicioBaseRepository;
        private readonly IMapper mapper;

        public ExercicioBaseService(IExercicioBaseRepository ExercicioBaseRepository, IMapper mapper)
        {
            this.ExercicioBaseRepository = ExercicioBaseRepository;
            this.mapper = mapper;
        }

        public ExercicioBaseDto Criar(ExercicioBaseCriarDto dto)
        {
            ExercicioBase exercicioBase = this.mapper.Map<ExercicioBase>(dto);
            this.ExercicioBaseRepository.Save(exercicioBase);

            return this.mapper.Map<ExercicioBaseDto>(exercicioBase);
        }

        public ExercicioBaseDto Editar(ExercicioBaseDto dto)
        {
            ExercicioBase exercicioBase = this.mapper.Map<ExercicioBase>(dto);
            this.ExercicioBaseRepository.Update(exercicioBase);

            return this.mapper.Map<ExercicioBaseDto>(exercicioBase);
        }

        public ExercicioBaseDto Apagar(Guid id)
        {
            ExercicioBase exercicioBase = this.ExercicioBaseRepository.GetById(id);

            if (!this.ExercicioBaseRepository.Exists(x => x.Id == id)) { throw new Exception("ExercicioBase nao existe"); }

            this.ExercicioBaseRepository.Delete(exercicioBase);

            return this.mapper.Map<ExercicioBaseDto>(exercicioBase);
        }

        public ExercicioBaseDto Obter(Guid id)
        {
            var exercicioBase = this.ExercicioBaseRepository.GetById(id);
            return this.mapper.Map<ExercicioBaseDto>(exercicioBase);
        }

        public IEnumerable<ExercicioBaseDto> ObterTodos()
        {
            var exercicioBase = this.ExercicioBaseRepository.GetAll();
            return this.mapper.Map<IEnumerable<ExercicioBaseDto>>(exercicioBase);
        }


        public IEnumerable<ExercicioBaseDto> BuscarPorParteNome(string partenome)
        {
            var listaExerciciosBase = ExercicioBaseRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (IEnumerable<ExercicioBaseDto>)listaExerciciosBase;

        }

    }
}
