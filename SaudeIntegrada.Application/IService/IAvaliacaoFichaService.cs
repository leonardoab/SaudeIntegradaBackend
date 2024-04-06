using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.IService
{
    public interface IAvaliacaoFichaService
    {
        AvaliacaoFichaDto Criar(AvaliacaoFichaDto dto);

        AvaliacaoFichaDto Editar(AvaliacaoFichaDto dto);

        AvaliacaoFichaDto Apagar(AvaliacaoFichaDto dto);

        AvaliacaoFichaDto Obter(Guid id);

        IEnumerable<AvaliacaoFichaDto> ObterTodos();
    }
}
