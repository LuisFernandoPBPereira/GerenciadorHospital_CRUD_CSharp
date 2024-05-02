using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelLaudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagemLaudo",
                table: "Laudos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoImagemLaudo",
                table: "Laudos");
        }
    }
}
