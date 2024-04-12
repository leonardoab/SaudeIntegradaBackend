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
        FichaDto Criar(FichaCriarDto dto);

        FichaDto Editar(FichaDto dto);

        FichaDto Apagar(Guid id);

        FichaDto Obter(Guid id);

        IEnumerable<FichaDto> ObterTodos();

        IEnumerable<FichaDto> BuscarPorParteNome(string partenome);
    }
}
