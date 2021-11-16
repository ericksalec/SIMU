using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class AddQuestaoR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestaoRespondida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prova = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Enunciado = table.Column<string>(type: "varchar(5000)", nullable: false),
                    TipoAssunto = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespostaMarcada = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Acerto = table.Column<bool>(type: "bit", nullable: false),
                    AnoProva = table.Column<string>(type: "varchar(20)", nullable: false),
                    A = table.Column<string>(type: "varchar(1000)", nullable: false),
                    B = table.Column<string>(type: "varchar(1000)", nullable: false),
                    C = table.Column<string>(type: "varchar(1000)", nullable: false),
                    D = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoRespondida", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestaoRespondida");
        }
    }
}
