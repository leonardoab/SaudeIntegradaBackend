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
        private  IPessoaRepository PessoaRepository;
        private  IMapper mapper;
        private  IContaRepository ContaRepository;

        public PessoaService(IPessoaRepository PessoaRepository, IMapper mapper, IContaRepository ContaRepository)
        {
            this.PessoaRepository = PessoaRepository;
            this.mapper = mapper;
            this.ContaRepository = ContaRepository;
        }

        public PessoaDto Criar(PessoaCriarDto dto)
        {
            Pessoa pessoa = this.mapper.Map<Pessoa>(dto);

            //ContaDto contaDto = ContaService.Obter(dto.IdConta);
            Conta conta = ContaRepository.GetById(dto.ContaId);
            //Conta conta = this.mapper.Map<Conta>(contaDto);

            pessoa.Conta = conta;            

            this.PessoaRepository.Save(pessoa);

            PessoaDto pessoaDto = this.mapper.Map<PessoaDto>(pessoa);

            pessoaDto.ContaId = dto.ContaId;

            return pessoaDto;
        }

        public PessoaDto Editar(PessoaDto dto)
        {
            Pessoa pessoa = this.mapper.Map<Pessoa>(dto);
            this.PessoaRepository.Update(pessoa);

            return this.mapper.Map<PessoaDto>(pessoa);
        }

        public PessoaDto Apagar(Guid id)
        {
            Pessoa pessoa = this.PessoaRepository.GetById(id);

            if (!this.PessoaRepository.Exists(x => x.Id == id)) { throw new Exception("Pessoa nao existe"); }

            
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
