using Advocacia.Domain.Entities;
using Advocacia.Domain.Repositories;
using Advocacia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Infra.Data.Repositories
{
    public class Base<E> : IBase<E> where E : class
    {
        private readonly AdvocaciaContext _contexto;

        public Base(AdvocaciaContext contexto)
        {
            _contexto = contexto;
        }

        public virtual async Task<int> Criar(E entidade)
        {
            await _contexto.Set<E>().AddAsync(entidade);
            return await _contexto.SaveChangesAsync();
        }


        public virtual async Task<int> Excluir(Guid id)
        {
            try
            {
                _contexto.Set<E>().Remove(await BuscarPeloId(id));
                return await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public virtual async Task<int> Atualizar(E entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync();
        }

        public virtual async Task<List<E>> BuscarTodos()
        {
            return await _contexto.Set<E>().ToListAsync();
        }

        public async Task<List<Cliente>> BuscarPorNome(string nome)
        {
            return await _contexto.Cliente.Where(x =>
                string.IsNullOrEmpty(nome) || x.Nome.Contains(nome)
            )
            .OrderBy(x => x.Nome)
            .ToListAsync();
        }

        public virtual async Task<E> BuscarPeloId(Guid id)
        {
            return await _contexto.Set<E>().FindAsync(id);
        }

       
    }
}
