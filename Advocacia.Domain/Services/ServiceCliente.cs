using Advocacia.Domain.Entities;
using Advocacia.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IBase<Cliente> _repositorio;

        public ServiceCliente(IBase<Cliente> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> Criar(Guid id, Cliente cliente)
        {
            cliente.Id = id;

            return await _repositorio.Criar(cliente);
        }

        public async Task<int> Atualizar(Guid id, Cliente cliente)
        {
            cliente.Id = id;
            return await _repositorio.Atualizar(cliente);
        }

        public async Task<int> Excluir(Guid id)
        {
            return await _repositorio.Excluir(id);
        }

        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _repositorio.BuscarTodos();
        }

        public async Task<List<Cliente>> BuscarFiltro(string nome, string documento)
        {
            return await _repositorio.BuscarFiltro(nome, documento);
        }

        public async Task<Cliente> BuscarPorId(Guid id)
        {
            return await _repositorio.BuscarPeloId(id);
        }

       
    }
}
