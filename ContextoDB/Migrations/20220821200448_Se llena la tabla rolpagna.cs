using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class Sellenalatablarolpagna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesPagina",
                columns: new[] { "PaginaId", "RolId", "Activo" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 1, true },
                    { 3, 1, true },
                    { 4, 1, true }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 21, 14, 4, 47, 917, DateTimeKind.Local).AddTicks(3100));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 4, 7, 20, 41, 12, 328, DateTimeKind.Local).AddTicks(104));
        }
    }
}
