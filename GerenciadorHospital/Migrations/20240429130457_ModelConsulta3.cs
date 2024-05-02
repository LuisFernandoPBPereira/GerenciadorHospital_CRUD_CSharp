using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class ModelConsulta3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistroConsultaModelConsultaId",
                table: "Laudos");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_MedicoId",
                table: "Laudos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_PacienteId",
                table: "Laudos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Medicos_MedicoId",
                table: "Laudos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_Pacientes_PacienteId",
                table: "Laudos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Medicos_MedicoId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Pacientes_PacienteId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_MedicoId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_PacienteId",
                table: "Laudos");

            migrationBuilder.AddColumn<int>(
                name: "RegistroConsultaModelConsultaId",
                table: "Laudos",
                type: "int",
                nullable: true);
        }
    }
}
