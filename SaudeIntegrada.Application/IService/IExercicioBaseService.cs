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
        ExercicioBaseDto Criar(ExercicioBaseCriarDto dto);

        ExercicioBaseDto Editar(ExercicioBaseDto dto);

        ExercicioBaseDto Apagar(Guid id);

        ExercicioBaseDto Obter(Guid id);

        IEnumerable<ExercicioBaseDto> ObterTodos();

        List<ExercicioBaseDto> BuscarPorParteNome(string partenome);
    }
}
