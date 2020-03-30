using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfilCore.Migrations
{
    public partial class renomeandoPropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                schema: "dbo",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "Descricao",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoPerfil",
                schema: "dbo",
                table: "Perfil",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoFuncao",
                schema: "dbo",
                table: "Funcionalidade",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoPerfil",
                schema: "dbo",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "DescricaoFuncao",
                schema: "dbo",
                table: "Funcionalidade");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                schema: "dbo",
                table: "Perfil",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                schema: "dbo",
                table: "Funcionalidade",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
