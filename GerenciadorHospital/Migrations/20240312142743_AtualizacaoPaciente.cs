using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvenioMedico",
                table: "Pacientes");

            migrationBuilder.AddColumn<int>(
                name: "ConvenioId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConvenioMedicoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ConvenioId",
                table: "Pacientes",
                column: "ConvenioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Convenios_ConvenioId",
                table: "Pacientes",
                column: "ConvenioId",
                principalTable: "Convenios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Convenios_ConvenioId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ConvenioId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConvenioId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ConvenioMedicoId",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "ConvenioMedico",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
