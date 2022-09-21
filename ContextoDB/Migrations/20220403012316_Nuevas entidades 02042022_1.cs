using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContextoDB.Migrations
{
    public partial class Nuevasentidades02042022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesPagina",
                table: "RolesPagina");

            migrationBuilder.DropIndex(
                name: "IX_RolesPagina_RolId",
                table: "RolesPagina");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RolesPagina");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesPagina",
                table: "RolesPagina",
                columns: new[] { "RolId", "PaginaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesPagina",
                table: "RolesPagina");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RolesPagina",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesPagina",
                table: "RolesPagina",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPagina_RolId",
                table: "RolesPagina",
                column: "RolId");
        }
    }
}
