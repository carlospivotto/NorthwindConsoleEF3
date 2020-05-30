using System;
using System.Collections;
using System.Collections.Generic;

namespace NorthwindConsoleEF3.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<DetalhamentoPedido> ProdutosPedido { get; set; }
    }
}
