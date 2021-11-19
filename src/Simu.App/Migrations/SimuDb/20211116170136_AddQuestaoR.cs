using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.App.Migrations.SimuDb
{
    public partial class AddQuestaoR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Respondidas = table.Column<int>(type: "int", nullable: false),
                    Acertos = table.Column<int>(type: "int", nullable: false),
                    Erros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dado", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UsuarioId = table.Column<string>(type: "varchar(50)", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(5000)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: true),
                    UploadImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Prova = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prova = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Enunciado = table.Column<string>(type: "varchar(5000)", nullable: false),
                    TipoAssunto = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Resposta = table.Column<string>(type: "varchar(1000)", nullable: false),
                    AnoProva = table.Column<string>(type: "varchar(20)", nullable: false),
                    A = table.Column<string>(type: "varchar(1000)", nullable: false),
                    B = table.Column<string>(type: "varchar(1000)", nullable: false),
                    C = table.Column<string>(type: "varchar(1000)", nullable: false),
                    D = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questao_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prova",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prova_Questao_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prova_QuestaoId",
                table: "Prova",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_TarefaId",
                table: "Questao",
                column: "TarefaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Dado");

            migrationBuilder.DropTable(
                name: "Prova");

            migrationBuilder.DropTable(
                name: "QuestaoRespondida");

            migrationBuilder.DropTable(
                name: "Questao");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
