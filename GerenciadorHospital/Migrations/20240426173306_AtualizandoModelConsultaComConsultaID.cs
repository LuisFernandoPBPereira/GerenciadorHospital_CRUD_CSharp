using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoModelConsultaComConsultaID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_RegistrosConsultas_RegistroConsultaModelId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "RegistroConsultaModelId",
                table: "Laudos",
                newName: "ConsultaId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_RegistroConsultaModelId",
                table: "Laudos",
                newName: "IX_Laudos_ConsultaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_RegistrosConsultas_ConsultaId",
                table: "Laudos",
                column: "ConsultaId",
                principalTable: "RegistrosConsultas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laudos_RegistrosConsultas_ConsultaId",
                table: "Laudos");

            migrationBuilder.RenameColumn(
                name: "ConsultaId",
                table: "Laudos",
                newName: "RegistroConsultaModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Laudos_ConsultaId",
                table: "Laudos",
                newName: "IX_Laudos_RegistroConsultaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laudos_RegistrosConsultas_RegistroConsultaModelId",
                table: "Laudos",
                column: "RegistroConsultaModelId",
                principalTable: "RegistrosConsultas",
                principalColumn: "Id");
        }
    }
}
