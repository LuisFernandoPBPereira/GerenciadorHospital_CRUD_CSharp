using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPacienteEMedico2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Medicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Medicos",
                type: "int",
                nullable: true);
        }
    }
}
