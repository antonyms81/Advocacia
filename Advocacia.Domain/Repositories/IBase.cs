using Advocacia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Domain.Repositories
{
    public interface IBase<E> where E : class
    {
        Task<int> Criar(E entidade);
        Task<int> Excluir(Guid id);
        Task<int> Atualizar(E entidade);
        Task<List<E>> BuscarTodos();
        Task<List<Cliente>> BuscarPorNome(string nome);
        Task<E> BuscarPeloId(Guid id);
        

    }
}
