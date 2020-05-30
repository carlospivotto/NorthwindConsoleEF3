using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindConsoleEF3.Migrations
{
    public partial class Empregado_CartaoAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartaoAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<string>(nullable: true),
                    EmpregadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartaoAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartaoAcesso_Empregados_EmpregadoId",
                        column: x => x.EmpregadoId,
                        principalTable: "Empregados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartaoAcesso_EmpregadoId",
                table: "CartaoAcesso",
                column: "EmpregadoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartaoAcesso");
        }
    }
}
