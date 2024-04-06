using SaudeIntegrada.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IPessoaService
    {
        PessoaDto Criar(PessoaDto dto);

        PessoaDto Editar(PessoaDto dto);

        PessoaDto Apagar(PessoaDto dto);

        PessoaDto Obter(Guid id);

        IEnumerable<PessoaDto> ObterTodos();
    }
}
