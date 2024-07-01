using Advocacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Domain.Services
{
    public interface IServiceCliente
    {
        Task<int> Criar(Guid id, Cliente cotacao);
        Task<int> Excluir(Guid id);
        Task<int> Atualizar(Guid id, Cliente cotacao); 
        Task<List<Cliente>> BuscarTodos();
        Task<List<Cliente>> BuscarPorNome(string nome);
        Task<Cliente> BuscarPorId(Guid id);
       

    }
}
