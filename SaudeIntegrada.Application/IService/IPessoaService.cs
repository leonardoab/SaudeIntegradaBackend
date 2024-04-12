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
        PessoaDto Criar(PessoaCriarDto dto);

        PessoaDto Editar(PessoaDto dto);

        PessoaDto Apagar(Guid id);

        PessoaDto Obter(Guid id);

        IEnumerable<PessoaDto> ObterTodos();
    }
}
