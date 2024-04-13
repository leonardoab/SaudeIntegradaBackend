using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Repository;
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
        private readonly IFichaRepository FichaRepository;
        private readonly IExercicioBaseRepository ExercicioBaseRepository;

        public ExercicioFichaService(IExercicioFichaRepository ExercicioFichaRepository, IMapper mapper, IFichaRepository FichaRepository, IExercicioBaseRepository ExercicioBaseRepository)
        {
            this.ExercicioFichaRepository = ExercicioFichaRepository;
            this.mapper = mapper;
            this.FichaRepository = FichaRepository;
            this.ExercicioBaseRepository = ExercicioBaseRepository;
        }

        public ExercicioFichaDto Criar(ExercicioFichaCriarDto dto)
        {
            ExercicioFicha exercicioFicha = this.mapper.Map<ExercicioFicha>(dto);

            ExercicioBase exercicioBase = this.ExercicioBaseRepository.GetById(dto.IdExercicioBase);

            exercicioFicha.ExercicioBase = exercicioBase;

            this.ExercicioFichaRepository.Save(exercicioFicha);

            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public ExercicioFichaDto Editar(ExercicioFichaDto dto)
        {
            ExercicioFicha exercicioFicha = this.mapper.Map<ExercicioFicha>(dto);

            ExercicioBase exercicioBase = ExercicioBaseRepository.GetById(dto.IdExercicioBase);

            exercicioFicha.ExercicioBase = exercicioBase;

            this.ExercicioFichaRepository.Update(exercicioFicha);

            return this.mapper.Map<ExercicioFichaDto>(exercicioFicha);
        }

        public ExercicioFichaDto Apagar(Guid id)
        {
            ExercicioFicha exercicioFicha = this.ExercicioFichaRepository.GetById(id);

            if (!this.ExercicioFichaRepository.Exists(x => x.Id == id)) { throw new Exception("ExercicioFicha nao existe"); }

            
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

        public bool AssociarFichaExercicioFicha(FichaExercicioFichaDto dto)
        {

            Ficha ficha = FichaRepository.GetById(dto.FichaId);

            ExercicioFicha exercicioFicha = ExercicioFichaRepository.GetById(dto.ExercicioFichaId);

            if (ficha != null && exercicioFicha != null)
            {

                if (ficha.ExerciciosFicha == null)
                {

                    ficha.ExerciciosFicha = new List<ExercicioFicha>();

                }

                ficha.ExerciciosFicha.Add(exercicioFicha);

                FichaRepository.Update(ficha);

                return true;


            }
            else
            {

                return false;

            }




        }



    }
}
