using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class ModelConsulta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Medicos_MedicoId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_Pacientes_PacienteId",
                table: "Laudos");

            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_RegistrosConsultas_ConsultaId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_MedicoId",
                table: "Laudos");

            migrationBuilder.DropIndex(
                name: "IX_Laudos_PacienteId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "ConsultaId",
                table: "Laudos",
                newName: "RegistroConsultaModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_ConsultaId",
                table: "Laudos",
                newName: "IX_Laudos_RegistroConsultaModelId");

            migrationBuilder.AddColumn<int>(
                name: "RegistroConsultaModelConsultaId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_RegistrosConsultas_RegistroConsultaModelId",
                table: "Laudos",
                column: "RegistroConsultaModelId",
                principalTable: "RegistrosConsultas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_RegistrosConsultas_RegistroConsultaModelId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "RegistroConsultaModelConsultaId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "RegistroConsultaModelId",
                table: "Laudos",
                newName: "ConsultaId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_RegistroConsultaModelId",
                table: "Laudos",
                newName: "IX_Laudos_ConsultaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_RegistrosConsultas_ConsultaId",
                table: "Laudos",
                column: "ConsultaId",
                principalTable: "RegistrosConsultas",
                principalColumn: "Id");
        }
    }
}
