using System;

namespace NorthwindConsoleEF3.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
