using System.Collections.Generic;

namespace NorthwindConsoleEF3.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompanhia { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
