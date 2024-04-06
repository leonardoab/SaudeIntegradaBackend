using SaudeIntegrada.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IExercicioFichaService
    {
        ExercicioFichaDto Criar(ExercicioFichaDto dto);

        ExercicioFichaDto Editar(ExercicioFichaDto dto);

        ExercicioFichaDto Apagar(ExercicioFichaDto dto);

        ExercicioFichaDto Obter(Guid id);

        IEnumerable<ExercicioFichaDto> ObterTodos();
    }
}
