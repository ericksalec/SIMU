using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simu.Data.Migrations
{
    public partial class NumeroQuestao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "E",
                table: "Questao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Questao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Dado",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "E",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Questao");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Dado",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
