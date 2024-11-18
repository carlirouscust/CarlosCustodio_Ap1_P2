using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarlosCustodio_Ap1_P2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticulosC",
                columns: table => new
                {
                    articuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    existencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosC", x => x.articuloId);
                });

            migrationBuilder.CreateTable(
                name: "combo",
                columns: table => new
                {
                    combosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vendido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combo", x => x.combosId);
                });

            migrationBuilder.InsertData(
                table: "ArticulosC",
                columns: new[] { "articuloId", "costo", "descripcion", "existencia", "precio" },
                values: new object[,]
                {
                    { 1, 2500.00m, "RAM Corsair 16GB", 100m, 5000.00m },
                    { 2, 1500.00m, "Disco Duro HP 524GB", 100m, 3000.00m },
                    { 3, 15000.00m, "Intel i7 11va Gen", 100m, 35000.00m },
                    { 4, 3000.00m, "Power Suply Corsair", 100m, 5000.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosC");

            migrationBuilder.DropTable(
                name: "combo");
        }
    }
}
