using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class Metododecifrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "Password" },
                values: new object[] { new DateTime(2022, 4, 5, 20, 19, 7, 24, DateTimeKind.Local).AddTicks(6059), "agBsAGEAcgBhAA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaRegistro", "Password" },
                values: new object[] { new DateTime(2022, 4, 4, 18, 59, 56, 93, DateTimeKind.Local).AddTicks(6045), "jlara" });
        }
    }
}
