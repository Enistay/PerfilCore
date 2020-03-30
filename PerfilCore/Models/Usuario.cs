using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Models
{
    public class Usuario : EntityBase
    {                                                                     
        public int IdUsuario { get; set; }
        public bool Ativo { get; set; }
        public DateTime Cadastro { get; set; }        
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<UsuarioPerfil> ListaUsuarioPerfil { get; set; }
    }
}
