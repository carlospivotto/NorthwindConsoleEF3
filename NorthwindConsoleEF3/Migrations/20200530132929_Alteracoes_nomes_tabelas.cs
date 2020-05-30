using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindConsoleEF3.Migrations
{
    public partial class Alteracoes_nomes_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregado_Territorios_TerritorioId",
                table: "Empregado");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empregado",
                table: "Empregado");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Empregado",
                newName: "Empregados");

            migrationBuilder.RenameIndex(
                name: "IX_Empregado_TerritorioId",
                table: "Empregados",
                newName: "IX_Empregados_TerritorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empregados",
                table: "Empregados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregados_Territorios_TerritorioId",
                table: "Empregados",
                column: "TerritorioId",
                principalTable: "Territorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empregados_Territorios_TerritorioId",
                table: "Empregados");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empregados",
                table: "Empregados");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Empregados",
                newName: "Empregado");

            migrationBuilder.RenameIndex(
                name: "IX_Empregados_TerritorioId",
                table: "Empregado",
                newName: "IX_Empregado_TerritorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empregado",
                table: "Empregado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empregado_Territorios_TerritorioId",
                table: "Empregado",
                column: "TerritorioId",
                principalTable: "Territorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedor_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
