using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfilCore.Models;

namespace PerfilCore.Infra.Map
{
    public class FuncionalidadeMap : IEntityTypeConfiguration<Funcionalidade>
    {
        public void Configure(EntityTypeBuilder<Funcionalidade> builder)
        {
            builder.ToTable("Funcionalidade", schema: "dbo");
            builder.Ignore(b => b.Id);

            builder.HasKey(b => b.IdFuncionalidade);

            builder.Property(b => b.DescricaoFuncao).HasMaxLength(100).IsRequired().IsUnicode(false);

            builder.HasOne(b => b.Perfil).WithMany(b => b.ListaFuncionalidade).HasForeignKey(b => b.IdPerfil);

        }
    }
}