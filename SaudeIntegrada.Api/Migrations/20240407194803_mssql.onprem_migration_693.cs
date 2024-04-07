using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIntegrada.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonpremmigration693 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Pessoa_Id",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_AvaliacaoFicha_AvaliacaoFichaId",
                table: "Ficha");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Conta",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Conta",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Conta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaId",
                table: "Conta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "AvaliacaoFicha",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Metodo",
                table: "AvaliacaoFicha",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "AvaliacaoFicha",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZonaQueima",
                table: "AvaliacaoFicha",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_AvaliacaoFicha_AvaliacaoFichaId",
                table: "Ficha",
                column: "AvaliacaoFichaId",
                principalTable: "AvaliacaoFicha",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conta_Pessoa_PessoaId",
                table: "Conta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ficha_AvaliacaoFicha_AvaliacaoFichaId",
                table: "Ficha");

            migrationBuilder.DropIndex(
                name: "IX_Conta_PessoaId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "AvaliacaoFicha");

            migrationBuilder.DropColumn(
                name: "Metodo",
                table: "AvaliacaoFicha");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "AvaliacaoFicha");

            migrationBuilder.DropColumn(
                name: "ZonaQueima",
                table: "AvaliacaoFicha");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Conta",
                newName: "Login");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pessoa",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Conta_Pessoa_Id",
                table: "Conta",
                column: "Id",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ficha_AvaliacaoFicha_AvaliacaoFichaId",
                table: "Ficha",
                column: "AvaliacaoFichaId",
                principalTable: "AvaliacaoFicha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
