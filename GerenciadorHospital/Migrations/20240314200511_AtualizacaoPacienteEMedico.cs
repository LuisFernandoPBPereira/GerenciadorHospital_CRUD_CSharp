using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPacienteEMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExameId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Medicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Crm",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especializacao",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ExameId",
                table: "Pacientes",
                column: "ExameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_TiposExames_ExameId",
                table: "Pacientes",
                column: "ExameId",
                principalTable: "TiposExames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_TiposExames_ExameId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ExameId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ExameId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Crm",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "Especializacao",
                table: "Medicos");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Pacientes_PacienteId",
                table: "RegistrosConsultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }
    }
}
