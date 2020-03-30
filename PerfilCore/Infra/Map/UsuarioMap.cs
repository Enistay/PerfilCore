using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfilCore.Models;

namespace PerfilCore.Infra.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuario", schema: "dbo");

            builder.Ignore(b => b.Id);

            builder.HasKey(b => b.IdUsuario);

            builder.Property(b => b.Ativo).IsRequired();

            builder.Property(b => b.Cadastro).IsRequired();

            builder.Property(b => b.Senha).HasMaxLength(32).IsRequired().IsUnicode(false);

            builder.Property(b => b.Nome).HasMaxLength(150).IsRequired().IsUnicode(false);

            builder.Property(b => b.Email).HasMaxLength(150).IsRequired().IsUnicode(false);


        }
    }
}

