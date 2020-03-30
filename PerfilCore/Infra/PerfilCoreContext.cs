using Microsoft.EntityFrameworkCore;
using PerfilCore.Infra.Map;
using PerfilCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfilCore.Infra
{
    public class PerfilCoreContext : DbContext
    {
        public PerfilCoreContext(DbContextOptions<PerfilCoreContext> options) : base(options) {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Funcionalidade> Funcionalidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new FuncionalidadeMap());

            modelBuilder.Entity<UsuarioPerfil>()
            .HasKey(u => new {u.IdUsuario, u.IdPerfil});

            modelBuilder.Entity<UsuarioPerfil>()
                .HasOne(up => up.Usuario)
                .WithMany(p => p.ListaUsuarioPerfil)
                .HasForeignKey(up => up.IdUsuario);

            modelBuilder.Entity<UsuarioPerfil>()
                        .HasOne(pu => pu.Perfil)
                        .WithMany(t => t.ListaUsuarioPerfil)
                        .HasForeignKey(pu => pu.IdPerfil);
        }

    }
}
