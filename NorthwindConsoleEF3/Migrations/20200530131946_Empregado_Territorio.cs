using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindConsoleEF3.Migrations
{
    public partial class Empregado_Territorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Territorios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empregado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    TerritorioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empregado_Territorios_TerritorioId",
                        column: x => x.TerritorioId,
                        principalTable: "Territorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empregado_TerritorioId",
                table: "Empregado",
                column: "TerritorioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empregado");

            migrationBuilder.DropTable(
                name: "Territorios");
        }
    }
}
