using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthwindConsoleEF3.Migrations
{
    public partial class DetalhamentoPedido_Alteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalhamentoPedido_Pedidos_PedidoId",
                table: "DetalhamentoPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalhamentoPedido_Produtos_ProdutoId",
                table: "DetalhamentoPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalhamentoPedido",
                table: "DetalhamentoPedido");

            migrationBuilder.RenameTable(
                name: "DetalhamentoPedido",
                newName: "DetalhamentoPedidos");

            migrationBuilder.RenameIndex(
                name: "IX_DetalhamentoPedido_ProdutoId",
                table: "DetalhamentoPedidos",
                newName: "IX_DetalhamentoPedidos_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalhamentoPedidos",
                table: "DetalhamentoPedidos",
                columns: new[] { "PedidoId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhamentoPedidos_Pedidos_PedidoId",
                table: "DetalhamentoPedidos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhamentoPedidos_Produtos_ProdutoId",
                table: "DetalhamentoPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalhamentoPedidos_Pedidos_PedidoId",
                table: "DetalhamentoPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalhamentoPedidos_Produtos_ProdutoId",
                table: "DetalhamentoPedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalhamentoPedidos",
                table: "DetalhamentoPedidos");

            migrationBuilder.RenameTable(
                name: "DetalhamentoPedidos",
                newName: "DetalhamentoPedido");

            migrationBuilder.RenameIndex(
                name: "IX_DetalhamentoPedidos_ProdutoId",
                table: "DetalhamentoPedido",
                newName: "IX_DetalhamentoPedido_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalhamentoPedido",
                table: "DetalhamentoPedido",
                columns: new[] { "PedidoId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhamentoPedido_Pedidos_PedidoId",
                table: "DetalhamentoPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalhamentoPedido_Produtos_ProdutoId",
                table: "DetalhamentoPedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
