using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejercicio_dapper.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductosCampoDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Activo", "Descripcion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, true, "Core i7, 16GB RAM, 512GB SSD", "Laptop EliteBook", 1599.99m, 10 },
                    { 2, true, "IPS, HDR10, 99% sRGB", "Monitor 4K 27\"", 349.50m, 25 },
                    { 3, true, "Switches Blue, retroiluminado", "Teclado mecánico RGB", 89.99m, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Productos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
