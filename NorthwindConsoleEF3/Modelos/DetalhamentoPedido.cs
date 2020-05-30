namespace NorthwindConsoleEF3.Modelos
{
    public class DetalhamentoPedido
    {
        //FK e propriedade de navegação para Pedido
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        //FK e propriedade de navegação para Produto
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
