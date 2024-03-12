using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Medicos_MedicoId",
                table: "RegistrosConsultas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Medicos_MedicoId",
                table: "RegistrosConsultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Medicos_MedicoId",
                table: "RegistrosConsultas");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Medicos_MedicoId",
                table: "RegistrosConsultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
