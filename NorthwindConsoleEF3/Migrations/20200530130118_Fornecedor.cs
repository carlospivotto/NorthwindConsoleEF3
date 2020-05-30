using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindConsoleEF3.Migrations
{
    public partial class Fornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompanhia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Produtos");
        }
    }
}
