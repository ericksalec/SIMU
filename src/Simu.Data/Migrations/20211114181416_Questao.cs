using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class Questao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "varchar(5000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Questao",
                type: "varchar(5000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "varchar(8000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Questao",
                type: "varchar(8000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5000)");
        }
    }
}
