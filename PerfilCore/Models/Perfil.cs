using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Models
{
    public class Perfil : EntityBase
    {
        public int IdPerfil { get; set; }
        public string DescricaoPerfil { get; set; }
        public ICollection<UsuarioPerfil> ListaUsuarioPerfil { get; set; }
        public ICollection<Funcionalidade> ListaFuncionalidade { get; set; }
    }
}
