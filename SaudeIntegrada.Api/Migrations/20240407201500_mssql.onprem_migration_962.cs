using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaudeIntegrada.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonpremmigration962 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Pessoa",
                newName: "Sexo");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Conta",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Pessoa",
                newName: "Telefone");
        }
    }
}
