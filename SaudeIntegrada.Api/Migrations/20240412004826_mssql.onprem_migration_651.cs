using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIntegrada.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonpremmigration651 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoFicha_Pessoa_PessoaId",
                table: "AvaliacaoFicha");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioFicha_ExercicioBase_ExercicioBaseId",
                table: "ExercicioFicha");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoFicha_Pessoa_PessoaId",
                table: "AvaliacaoFicha",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioFicha_ExercicioBase_ExercicioBaseId",
                table: "ExercicioFicha",
                column: "ExercicioBaseId",
                principalTable: "ExercicioBase",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoFicha_Pessoa_PessoaId",
                table: "AvaliacaoFicha");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercicioFicha_ExercicioBase_ExercicioBaseId",
                table: "ExercicioFicha");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoFicha_Pessoa_PessoaId",
                table: "AvaliacaoFicha",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioFicha_ExercicioBase_ExercicioBaseId",
                table: "ExercicioFicha",
                column: "ExercicioBaseId",
                principalTable: "ExercicioBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Conta_ContaId",
                table: "Pessoa",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
