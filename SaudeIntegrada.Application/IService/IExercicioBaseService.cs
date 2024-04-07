using SaudeIntegrada.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IExercicioBaseService
    {
        ExercicioBaseDto Criar(ExercicioBaseDto dto);

        ExercicioBaseDto Editar(ExercicioBaseDto dto);

        ExercicioBaseDto Apagar(ExercicioBaseDto dto);

        ExercicioBaseDto Obter(Guid id);

        IEnumerable<ExercicioBaseDto> ObterTodos();

        IEnumerable<ExercicioBaseDto> BuscarPorParteNome(string partenome);
    }
}
