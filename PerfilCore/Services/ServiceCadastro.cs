using PerfilCore.Interfaces;
using PerfilCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PerfilCore.Services
{
    public class ServiceCadastro : IServiceCadastro
    {
        private readonly IRepositoryBase RepositoryBase;

        public ServiceCadastro(IRepositoryBase repositoryBase)
        {
            RepositoryBase = repositoryBase;
        }

        public async Task<TEntidade> Add<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            try
            {
                return await RepositoryBase.Add<TEntidade>(entidade);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TEntidade>> Get<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : EntityBase, new()
        {
            try
            {
                return await RepositoryBase.Get<TEntidade>(filtro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TEntidade>> GetAll<TEntidade>() where TEntidade : EntityBase, new()
        {
            try
            {
                return await RepositoryBase.GetAll<TEntidade>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Remove<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            try
            {                   
                return await RepositoryBase.Remove<TEntidade>(entidade);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async  Task<bool> Update<TEntidade>(TEntidade entidade) where TEntidade : EntityBase, new()
        {
            try
            {
                return await RepositoryBase.Update<TEntidade>(entidade);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
