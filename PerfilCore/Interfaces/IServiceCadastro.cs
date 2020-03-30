using PerfilCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PerfilCore.Interfaces
{
    public interface IServiceCadastro
    {
        Task<TEntidade> Add<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new();
        Task<bool> Update<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new();
        Task<bool> Remove<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new();
        Task<IEnumerable<TEntidade>> Get<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : EntityBase, new();
        Task<IEnumerable<TEntidade>> GetAll<TEntidade>() where TEntidade : EntityBase, new();
    }
}
