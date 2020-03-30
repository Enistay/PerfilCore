using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Models
{
    public class UsuarioPerfil : EntityBase
    {  
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
    }
}
