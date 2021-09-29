using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TiendaServicios.Api.CarritoCompra.Migrations
{
    public partial class MigrationMySqlInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarritoSesions",
                columns: table => new
                {
                    CarritoSesionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesions", x => x.CarritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalle",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ProductoSelecciondo = table.Column<string>(nullable: true),
                    CarritoSesionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalle", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalle_CarritoSesions_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "CarritoSesions",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalle_CarritoSesionId",
                table: "CarritoSesionDetalle",
                column: "CarritoSesionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalle");

            migrationBuilder.DropTable(
                name: "CarritoSesions");
        }
    }
}
