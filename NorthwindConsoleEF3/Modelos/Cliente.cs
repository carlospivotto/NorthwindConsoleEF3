using System.Collections.Generic;

namespace NorthwindConsoleEF3.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompanhia { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
