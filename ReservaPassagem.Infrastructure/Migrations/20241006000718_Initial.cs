using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaPassagem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passageiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimeiroNome = table.Column<string>(name: "Primeiro Nome", type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    UltimoNome = table.Column<string>(name: "Ultimo Nome", type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroVoo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Origem_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origem_Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino_Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Chegada = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    CompanhiaAerea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusReserva = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassageiroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Passageiro_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Passageiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    VooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assentos_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assentos_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assentos_ReservaId",
                table: "Assentos",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Assentos_VooId",
                table: "Assentos",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PassageiroId",
                table: "Reservas",
                column: "PassageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas",
                column: "VooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assentos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Passageiro");

            migrationBuilder.DropTable(
                name: "Voos");
        }
    }
}
