using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfilCore.Migrations
{
    public partial class AjustePerfilEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionalidade_Perfil_PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.DropIndex(
                name: "IX_Funcionalidade_PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.DropColumn(
                name: "PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.AddColumn<int>(
                name: "IdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidade_IdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionalidade_Perfil_IdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                column: "IdPerfil",
                principalSchema: "dbo",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionalidade_Perfil_IdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.DropIndex(
                name: "IX_Funcionalidade_IdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.AddColumn<int>(
                name: "PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidade_PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                column: "PerfilIdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionalidade_Perfil_PerfilIdPerfil",
                schema: "dbo",
                table: "Funcionalidade",
                column: "PerfilIdPerfil",
                principalSchema: "dbo",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
