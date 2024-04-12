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
        AvaliacaoFichaDto Criar(AvaliacaoFichaCriarDto dto);

        AvaliacaoFichaDto Editar(AvaliacaoFichaDto dto);

        AvaliacaoFichaDto Apagar(Guid id);

        AvaliacaoFichaDto Obter(Guid id);

        IEnumerable<AvaliacaoFichaDto> ObterTodos();
    }
}
