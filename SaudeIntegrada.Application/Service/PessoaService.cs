using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository PessoaRepository;
        private readonly IMapper mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            PessoaRepository = pessoaRepository;
            this.mapper = mapper;
        }


        public PessoaDto Criar(PessoaDto dto)
        {
            Pessoa Pessoa = this.mapper.Map<Pessoa>(dto);
            this.PessoaRepository.Save(Pessoa);

            return this.mapper.Map<PessoaDto>(Pessoa);
        }

        public PessoaDto Obter(Guid id)
        {
            var Pessoa = this.PessoaRepository.Get(id);
            return this.mapper.Map<PessoaDto>(Pessoa);
        }

        public IEnumerable<PessoaDto> ObterTodos()
        {
            var Pessoa = this.PessoaRepository.GetAll();
            return this.mapper.Map<IEnumerable<PessoaDto>>(Pessoa);
        }

    }
}
