using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaPassagem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangetempoVoocolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorasVoo",
                table: "Voos",
                newName: "TempoVoo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempoVoo",
                table: "Voos",
                newName: "HorasVoo");
        }
    }
}
