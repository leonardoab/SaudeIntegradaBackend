using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIntegrada.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonpremmigration590 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Pessoa_PessoaId",
                table: "Conta");

            migrationBuilder.DropIndex(
                name: "IX_Conta_PessoaId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Conta");

            migrationBuilder.AddColumn<Guid>(
                name: "ContaId",
                table: "Pessoa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Carga",
                table: "ExercicioFicha",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Objetivo",
                table: "AvaliacaoFicha",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ContaId",
                table: "Pessoa",
                column: "ContaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_ContaId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Carga",
                table: "ExercicioFicha");

            migrationBuilder.DropColumn(
                name: "Objetivo",
                table: "AvaliacaoFicha");

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaId",
                table: "Conta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Conta_PessoaId",
                table: "Conta",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Pessoa_PessoaId",
                table: "Conta",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
