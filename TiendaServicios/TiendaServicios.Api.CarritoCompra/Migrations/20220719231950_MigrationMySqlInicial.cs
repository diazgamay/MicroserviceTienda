﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesions", x => x.CarritoSesionId);
                });

            migrationBuilder.CreateTable(
                name: "CarritoSesionDetalles",
                columns: table => new
                {
                    CarritoSesionDetalleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ProductoSelecciondo = table.Column<string>(nullable: true),
                    CarritoSesionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoSesionDetalles", x => x.CarritoSesionDetalleId);
                    table.ForeignKey(
                        name: "FK_CarritoSesionDetalles_CarritoSesions_CarritoSesionId",
                        column: x => x.CarritoSesionId,
                        principalTable: "CarritoSesions",
                        principalColumn: "CarritoSesionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoSesionDetalles_CarritoSesionId",
                table: "CarritoSesionDetalles",
                column: "CarritoSesionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoSesionDetalles");

            migrationBuilder.DropTable(
                name: "CarritoSesions");
        }
    }
}
