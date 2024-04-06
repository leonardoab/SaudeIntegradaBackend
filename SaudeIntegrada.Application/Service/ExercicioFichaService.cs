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
    public class ExercicioFichaService : IExercicioFichaService
    {
        private readonly IExercicioFichaRepository ExercicioFichaRepository;
        private readonly IMapper mapper;

        public ExercicioFichaService(IExercicioFichaRepository ExercicioFichaRepository, IMapper mapper)
        {
            this.ExercicioFichaRepository = ExercicioFichaRepository;
            this.mapper = mapper;
        }

        public ExercicioFichaDto Criar(ExercicioFichaDto dto)
        {
            ExercicioFicha exercicioFicha = this.mapper.Map<ExercicioFicha>(dto);
            this.ExercicioFichaRepository.Save(exercicioFicha);

            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public ExercicioFichaDto Editar(ExercicioFichaDto dto)
        {
            ExercicioFicha exercicioFicha = this.mapper.Map<ExercicioFicha>(dto);
            this.ExercicioFichaRepository.Update(exercicioFicha);

            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public ExercicioFichaDto Apagar(ExercicioFichaDto dto)
        {
            ExercicioFicha exercicioFicha = this.mapper.Map<ExercicioFicha>(dto);
            this.ExercicioFichaRepository.Delete(exercicioFicha);

            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public ExercicioFichaDto Obter(Guid id)
        {
            var exercicioFicha = this.ExercicioFichaRepository.GetById(id);
            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public IEnumerable<ExercicioFichaDto> ObterTodos()
        {
            var exercicioFicha = this.ExercicioFichaRepository.GetAll();
            return this.mapper.Map<IEnumerable<ExercicioFichaDto>>(exercicioFicha);
        }

    }
}
