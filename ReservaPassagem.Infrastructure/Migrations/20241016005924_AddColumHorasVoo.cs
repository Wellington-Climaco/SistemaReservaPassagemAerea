using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaPassagem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumHorasVoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chegada",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "Partida",
                table: "Voos");

            migrationBuilder.AddColumn<string>(
                name: "HorasVoo",
                table: "Voos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeAssentos",
                table: "Voos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasVoo",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "QuantidadeAssentos",
                table: "Voos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Chegada",
                table: "Voos",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Partida",
                table: "Voos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
