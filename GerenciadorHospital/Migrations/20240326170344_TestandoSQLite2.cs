using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class TestandoSQLite2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Pacientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Medicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Medicos");
        }
    }
}
