using SaudeIntegrada.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IContaService
    {
        ContaDto Criar(ContaDto dto);

        ContaDto Editar(ContaDto dto);

        ContaDto Apagar(ContaDto dto);

        ContaDto Obter(Guid id);

        IEnumerable<ContaDto> ObterTodos();
    }
}
