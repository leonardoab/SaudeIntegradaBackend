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

        public PessoaService(IPessoaRepository PessoaRepository, IMapper mapper)
        {
            this.PessoaRepository = PessoaRepository;
            this.mapper = mapper;
        }

        public PessoaDto Criar(PessoaDto dto)
        {
            Pessoa pessoa = this.mapper.Map<Pessoa>(dto);
            this.PessoaRepository.Save(pessoa);

            return this.mapper.Map<PessoaDto>(pessoa);
        }

        public PessoaDto Editar(PessoaDto dto)
        {
            Pessoa pessoa = this.mapper.Map<Pessoa>(dto);
            this.PessoaRepository.Update(pessoa);

            return this.mapper.Map<PessoaDto>(pessoa);
        }

        public PessoaDto Apagar(PessoaDto dto)
        {
            Pessoa pessoa = this.mapper.Map<Pessoa>(dto);
            this.PessoaRepository.Delete(pessoa);

            return this.mapper.Map<PessoaDto>(pessoa);
        }

        public PessoaDto Obter(Guid id)
        {
            var pessoa = this.PessoaRepository.GetById(id);
            return this.mapper.Map<PessoaDto>(pessoa);
        }

        public IEnumerable<PessoaDto> ObterTodos()
        {
            var pessoa = this.PessoaRepository.GetAll();
            return this.mapper.Map<IEnumerable<PessoaDto>>(pessoa);
        }


    }
}
