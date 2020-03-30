using Microsoft.EntityFrameworkCore;
using PerfilCore.Interfaces;
using PerfilCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PerfilCore.Infra.Repositorio
{
    public class RepositoryBase : IRepositoryBase
    {
        public PerfilCoreContext PerfilCoreContext { get; set; }
        public RepositoryBase(PerfilCoreContext perfilCoreContext)
        {
            PerfilCoreContext = perfilCoreContext;
        }

        public async Task<TEntidade> Add<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            await PerfilCoreContext.Set<TEntidade>().AddAsync(entidade);
            await PerfilCoreContext.SaveChangesAsync();
            return entidade;
        }

        public async Task<bool> Update<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            PerfilCoreContext.Set<TEntidade>().Update(entidade);
            await PerfilCoreContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remove<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            PerfilCoreContext.Remove(entidade);
            await PerfilCoreContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntidade>> Get<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : EntityBase, new()
        {
            return await PerfilCoreContext.Set<TEntidade>().Where(filtro).ToListAsync();
        }

        public async Task<IEnumerable<TEntidade>> GetAll<TEntidade>() where TEntidade : EntityBase, new()
        {
            return await PerfilCoreContext.Set<TEntidade>().ToListAsync();
        }
    }
}
