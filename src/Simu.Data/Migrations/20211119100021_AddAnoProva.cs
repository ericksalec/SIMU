using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class AddAnoProva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questao_Tarefas_TarefaId",
                table: "Questao");

            migrationBuilder.DropIndex(
                name: "IX_Questao_TarefaId",
                table: "Questao");

            migrationBuilder.AddColumn<int>(
                name: "AnoProva",
                table: "Dado",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoProva",
                table: "Dado");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_TarefaId",
                table: "Questao",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questao_Tarefas_TarefaId",
                table: "Questao",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
