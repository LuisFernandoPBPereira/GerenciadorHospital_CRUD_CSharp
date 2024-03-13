using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorHospital.Migrations
{
    /// <inheritdoc />
    public partial class ConsultaAlterada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRetorno",
                table: "RegistrosConsultas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoConsulta",
                table: "RegistrosConsultas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "RegistrosConsultas",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRetorno",
                table: "RegistrosConsultas");

            migrationBuilder.DropColumn(
                name: "EstadoConsulta",
                table: "RegistrosConsultas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "RegistrosConsultas");
        }
    }
}
