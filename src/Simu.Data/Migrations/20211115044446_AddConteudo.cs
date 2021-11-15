using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class AddConteudo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Questao",
                newName: "Enunciado");

            migrationBuilder.AlterColumn<string>(
                name: "Prova",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<string>(
                name: "A",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnoProva",
                table: "Questao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "B",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "C",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "D",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoAssunto",
                table: "Questao",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "AnoProva",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "B",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "C",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "D",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "TipoAssunto",
                table: "Questao");

            migrationBuilder.RenameColumn(
                name: "Enunciado",
                table: "Questao",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Prova",
                table: "Questao",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)");
        }
    }
}
