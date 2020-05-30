using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindConsoleEF3.Modelos
{
    public class DetalhamentoPedido
    {
        //FK e propriedade de navegação para Pedido
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        //FK e propriedade de navegação para Produto
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
