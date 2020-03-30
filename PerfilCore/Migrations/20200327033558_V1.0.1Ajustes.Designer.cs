﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfilCore.Infra;

namespace PerfilCore.Migrations
{
    [DbContext(typeof(PerfilCoreContext))]
    [Migration("20200327033558_V1.0.1Ajustes")]
    partial class V101Ajustes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PerfilCore.Models.Funcionalidade", b =>
                {
                    b.Property<int>("IdFuncionalidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("PerfilIdPerfil")
                        .HasColumnType("int");

                    b.HasKey("IdFuncionalidade");

                    b.HasIndex("PerfilIdPerfil");

                    b.ToTable("Funcionalidade","dbo");
                });

            modelBuilder.Entity("PerfilCore.Models.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil","dbo");
                });

            modelBuilder.Entity("PerfilCore.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(32)")
                        .HasMaxLength(32)
                        .IsUnicode(false);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario","dbo");
                });

            modelBuilder.Entity("PerfilCore.Models.UsuarioPerfil", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdUsuario", "IdPerfil");

                    b.HasIndex("IdPerfil");

                    b.ToTable("UsuarioPerfil");
                });

            modelBuilder.Entity("PerfilCore.Models.Funcionalidade", b =>
                {
                    b.HasOne("PerfilCore.Models.Perfil", null)
                        .WithMany("ListaFuncionalidade")
                        .HasForeignKey("PerfilIdPerfil");
                });

            modelBuilder.Entity("PerfilCore.Models.UsuarioPerfil", b =>
                {
                    b.HasOne("PerfilCore.Models.Perfil", "Perfil")
                        .WithMany("ListaUsuarioPerfil")
                        .HasForeignKey("IdPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PerfilCore.Models.Usuario", "Usuario")
                        .WithMany("ListaUsuarioPerfil")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
