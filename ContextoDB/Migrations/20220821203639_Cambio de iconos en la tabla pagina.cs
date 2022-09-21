using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class Cambiodeiconosenlatablapagina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: "person");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: "badge");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: "menu_book");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: "description");

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 2, 1 },
                column: "Activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 3, 1 },
                column: "Activo",
                value: true);

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 4, 1 },
                column: "Activo",
                value: true);

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Icon",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Icon",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Icon",
                value: "menu");

            migrationBuilder.UpdateData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Icon",
                value: "page");

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 2, 1 },
                column: "Activo",
                value: false);

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 3, 1 },
                column: "Activo",
                value: false);

            migrationBuilder.UpdateData(
                table: "RolesPagina",
                keyColumns: new[] { "PaginaId", "RolId" },
                keyValues: new object[] { 4, 1 },
                column: "Activo",
                value: false);

            migrationBuilder.InsertData(
                table: "RolesPagina",
                columns: new[] { "PaginaId", "RolId", "Activo" },
                values: new object[] { 5, 1, false });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 21, 14, 4, 47, 917, DateTimeKind.Local).AddTicks(3100));
        }
    }
}
