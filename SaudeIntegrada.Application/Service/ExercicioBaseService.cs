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
    public class ExercicioBaseService : IExercicioBaseService
    {
        private readonly IExercicioBaseRepository ExercicioBaseRepository;
        private readonly IMapper mapper;

        public ExercicioBaseService(IExercicioBaseRepository exercicioBaseRepository, IMapper mapper)
        {
            ExercicioBaseRepository = exercicioBaseRepository;
            this.mapper = mapper;
        }
    }
}
