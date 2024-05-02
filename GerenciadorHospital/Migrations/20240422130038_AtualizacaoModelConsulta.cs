using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_Laudos_LaudoId",
                table: "RegistrosConsultas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosConsultas_LaudoId",
                table: "RegistrosConsultas");

            migrationBuilder.DropColumn(
                name: "LaudoId",
                table: "RegistrosConsultas");

            migrationBuilder.AddColumn<string>(
                name: "LaudoIds",
                table: "RegistrosConsultas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistroConsultaModelId",
                table: "Laudos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_RegistroConsultaModelId",
                table: "Laudos",
                column: "RegistroConsultaModelId");

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

            migrationBuilder.DropIndex(
                name: "IX_Laudos_RegistroConsultaModelId",
                table: "Laudos");

            migrationBuilder.DropColumn(
                name: "LaudoIds",
                table: "RegistrosConsultas");

            migrationBuilder.DropColumn(
                name: "RegistroConsultaModelId",
                table: "Laudos");

            migrationBuilder.AddColumn<int>(
                name: "LaudoId",
                table: "RegistrosConsultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosConsultas_LaudoId",
                table: "RegistrosConsultas",
                column: "LaudoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_Laudos_LaudoId",
                table: "RegistrosConsultas",
                column: "LaudoId",
                principalTable: "Laudos",
                principalColumn: "Id");
        }
    }
}
