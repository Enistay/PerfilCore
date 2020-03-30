using PerfilCore.Models;    
using System.Threading.Tasks;

namespace PerfilCore.Interfaces
{
    public interface IServicePerfil : IServiceCadastro
    {
        Task<Perfil> SalvarPerfil(Perfil perfil);
    }
}
