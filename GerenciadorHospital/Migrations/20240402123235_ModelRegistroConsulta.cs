using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class ModelRegistroConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExameId",
                table: "RegistrosConsultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosConsultas_ExameId",
                table: "RegistrosConsultas",
                column: "ExameId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosConsultas_TiposExames_ExameId",
                table: "RegistrosConsultas",
                column: "ExameId",
                principalTable: "TiposExames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosConsultas_TiposExames_ExameId",
                table: "RegistrosConsultas");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosConsultas_ExameId",
                table: "RegistrosConsultas");

            migrationBuilder.DropColumn(
                name: "ExameId",
                table: "RegistrosConsultas");
        }
    }
}
