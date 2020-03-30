using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfilCore.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "dbo",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false),
                    Cadastro = table.Column<DateTime>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Funcionalidade",
                schema: "dbo",
                columns: table => new
                {
                    IdFuncionalidade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    PerfilIdPerfil = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalidade", x => x.IdFuncionalidade);
                    table.ForeignKey(
                        name: "FK_Funcionalidade_Perfil_PerfilIdPerfil",
                        column: x => x.PerfilIdPerfil,
                        principalSchema: "dbo",
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    IdPerfil = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => new { x.IdUsuario, x.IdPerfil });
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalSchema: "dbo",
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidade_PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                column: "PerfilIdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_IdPerfil",
                schema: "dbo",
                table: "UsuarioPerfil",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionalidade",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");
        }
    }
}
