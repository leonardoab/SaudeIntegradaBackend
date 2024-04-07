using AutoMapper;
using SaudeIntegrada.Application.Dto;
using SaudeIntegrada.Application.IService;
using SaudeIntegrada.Domain.Domains;
using SaudeIntegrada.Domain.IRepository;
using SaudeIntegrada.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Application.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository ContaRepository;
        private readonly IMapper mapper;

        public ContaService(IContaRepository ContaRepository, IMapper mapper)
        {
            this.ContaRepository = ContaRepository;
            this.mapper = mapper;
        }

        public ContaDto Criar(ContaDto dto)
        {
            if (this.ContaRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuario já existente na base");

            if (this.ContaRepository.Exists(x => x.Telefone == dto.Telefone))
                throw new Exception("Usuario já existente na base");


            Conta conta = this.mapper.Map<Conta>(dto);

            conta.Ativo = true;            

            this.ContaRepository.Save(conta);

            return this.mapper.Map<ContaDto>(conta);
        }

        public ContaDto Editar(ContaDto dto)
        {
            Conta conta = this.mapper.Map<Conta>(dto);
            this.ContaRepository.Update(conta);

            return this.mapper.Map<ContaDto>(conta);
        }

        public ContaDto Apagar(ContaDto dto)
        {
            Conta conta = this.mapper.Map<Conta>(dto);
            this.ContaRepository.Delete(conta);

            return this.mapper.Map<ContaDto>(conta);
        }

        public ContaDto Obter(Guid id)
        {
            var conta = this.ContaRepository.GetById(id);
            return this.mapper.Map<ContaDto>(conta);
        }

        public IEnumerable<ContaDto> ObterTodos()
        {
            var conta = this.ContaRepository.GetAll();
            return this.mapper.Map<IEnumerable<ContaDto>>(conta);
        }

        public IEnumerable<ContaDto> BuscarPorEmail(string email)
        {
            var listaContas = ContaRepository.Find(x => x.Email == email).ToList();

            return (IEnumerable<ContaDto>)listaContas;

        }

        public IEnumerable<ContaDto> BuscarPorTelefone(string telefone)
        {
            var listaContas = ContaRepository.Find(x => x.Telefone == telefone).ToList();

            return (IEnumerable<ContaDto>)listaContas;

        }

    }
}
