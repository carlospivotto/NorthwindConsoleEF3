using System;
using System.Collections.Generic;

namespace NorthwindConsoleEF3.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<DetalhamentoPedido> ProdutosPedido { get; set; }
    }
}
