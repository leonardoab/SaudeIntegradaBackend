using SaudeIntegrada.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IFichaService
    {
        FichaDto Criar(FichaDto dto);

        FichaDto Editar(FichaDto dto);

        FichaDto Apagar(FichaDto dto);

        FichaDto Obter(Guid id);

        IEnumerable<FichaDto> ObterTodos();

        IEnumerable<FichaDto> BuscarPorParteNome(string partenome);
    }
}
