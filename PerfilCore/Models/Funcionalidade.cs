using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Models
{
    public class Funcionalidade : EntityBase
    {
        public int IdFuncionalidade { get; set; }
        public string DescricaoFuncao { get; set; }
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
    }
}
