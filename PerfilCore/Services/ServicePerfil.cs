using PerfilCore.Interfaces;
using PerfilCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Services
{
    public class ServicePerfil : ServiceCadastro, IServicePerfil
    {
        private readonly IRepositoryBase RepositoryBase;
        public ServicePerfil(IRepositoryBase repositoryBase) : base(repositoryBase)
        {
            RepositoryBase = repositoryBase;
        }

        public async Task<Perfil> SalvarPerfil(Perfil perfil)
        {                         
            if (perfil.IdPerfil > 0)
            {
                await RepositoryBase.Update<Perfil>(perfil);
            }
            else
            {
                var perfilAdd = new Perfil { DescricaoPerfil = perfil.DescricaoPerfil };

                await RepositoryBase.Add<Perfil>(perfilAdd);

                perfil.IdPerfil = perfilAdd.IdPerfil;
                await VerficarFuncionalidade(perfil);
            }

            return perfil;
        }


        private async Task VerficarFuncionalidade(Perfil perfil)
        {
            if (perfil.ListaFuncionalidade != null)
            {
                var funcao = perfil.ListaFuncionalidade.Where(x => x.IdFuncionalidade > 0);

                //busca funcionalidades cadastrados para atualizar             
               
                foreach (var item in funcao)
                {
                    var resultado =  await RepositoryBase.Get<Funcionalidade>(x => x.IdFuncionalidade == item.IdFuncionalidade);
                    var funcaoUpdate = resultado.FirstOrDefault();
                    if (funcaoUpdate != null)
                    {
                        if (!string.IsNullOrEmpty(item.DescricaoFuncao))
                        {
                            funcaoUpdate.DescricaoFuncao = item.DescricaoFuncao;
                        }

                        funcaoUpdate.IdPerfil = perfil.IdPerfil;
                        await RepositoryBase.Update<Funcionalidade>(funcaoUpdate);
                    }
                }

                //add novas
                var funcaoNova = perfil.ListaFuncionalidade.Where(x => x.IdFuncionalidade == 0);
                foreach(var item in funcaoNova)
                {
                    item.IdPerfil = perfil.IdPerfil;
                    await RepositoryBase.Add<Funcionalidade>(item);
                }
            }
        }
    }
}
