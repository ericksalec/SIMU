using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class FixQuestao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "varchar(5000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Tarefas",
                type: "varchar(10000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8000)");
        }
    }
}
