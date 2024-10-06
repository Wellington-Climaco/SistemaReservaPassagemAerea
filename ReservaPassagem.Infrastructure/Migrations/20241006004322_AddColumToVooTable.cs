using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaPassagem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumToVooTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Voos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Voos");
        }
    }
}
