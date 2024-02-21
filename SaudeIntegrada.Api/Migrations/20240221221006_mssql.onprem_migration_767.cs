using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIntegrada.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_767 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExercicioBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoFicha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VelocidadeExecucao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descanso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Duracao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataTesteCarga = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProximoTesteCarga = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoFicha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoFicha_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AvaliacaoFichaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ficha_AvaliacaoFicha_AvaliacaoFichaId",
                        column: x => x.AvaliacaoFichaId,
                        principalTable: "AvaliacaoFicha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioFicha",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sets = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Repeticoes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExercicioBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FichaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioFicha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercicioFicha_ExercicioBase_ExercicioBaseId",
                        column: x => x.ExercicioBaseId,
                        principalTable: "ExercicioBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercicioFicha_Ficha_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Ficha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoFicha_PessoaId",
                table: "AvaliacaoFicha",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioFicha_ExercicioBaseId",
                table: "ExercicioFicha",
                column: "ExercicioBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioFicha_FichaId",
                table: "ExercicioFicha",
                column: "FichaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_AvaliacaoFichaId",
                table: "Ficha",
                column: "AvaliacaoFichaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercicioFicha");

            migrationBuilder.DropTable(
                name: "ExercicioBase");

            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "AvaliacaoFicha");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
