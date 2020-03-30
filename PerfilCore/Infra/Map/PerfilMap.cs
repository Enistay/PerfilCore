using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfilCore.Models;


namespace PerfilCore.Infra.Map
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil", schema: "dbo");
            builder.Ignore(b => b.Id);

            builder.HasKey(b => b.IdPerfil);

            builder.Property(b => b.DescricaoPerfil).HasMaxLength(100).IsRequired().IsUnicode(false);

        }
    }
}
