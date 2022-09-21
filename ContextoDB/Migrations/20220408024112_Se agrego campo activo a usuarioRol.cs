using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class SeagregocampoactivoausuarioRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "RolesUsuario",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 4, 7, 20, 41, 12, 328, DateTimeKind.Local).AddTicks(104));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "RolesUsuario");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 4, 5, 20, 31, 44, 731, DateTimeKind.Local).AddTicks(4689));
        }
    }
}
