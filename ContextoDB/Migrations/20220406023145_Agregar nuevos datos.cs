using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class Agregarnuevosdatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Activo", "Clave", "Icono", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "catalogo", "Menu", "Catalogo" },
                    { 2, true, "seguridad", "Menu", "Seguridad" }
                });

            migrationBuilder.InsertData(
                table: "RolesUsuario",
                columns: new[] { "RolId", "UsuarioId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 4, 5, 20, 31, 44, 731, DateTimeKind.Local).AddTicks(4689));

            migrationBuilder.InsertData(
                table: "Paginas",
                columns: new[] { "Id", "Activo", "Clave", "Icon", "MenuId", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "usuario", "description", 1, "Usuario" },
                    { 2, true, "rol", "description", 1, "Rol" },
                    { 3, true, "menu", "menu", 2, "Menu" },
                    { 4, true, "pagina", "page", 2, "Pagina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paginas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RolesUsuario",
                keyColumns: new[] { "RolId", "UsuarioId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 4, 5, 20, 19, 7, 24, DateTimeKind.Local).AddTicks(6059));
        }
    }
}
