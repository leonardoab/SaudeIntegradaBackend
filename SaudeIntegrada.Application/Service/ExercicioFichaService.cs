using AutoMapper;
using SaudeIntegrada.Application.IService;
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

        public ExercicioFichaService(IExercicioFichaRepository exercicioFichaRepository, IMapper mapper)
        {
            ExercicioFichaRepository = exercicioFichaRepository;
            this.mapper = mapper;
        }
    }
}
