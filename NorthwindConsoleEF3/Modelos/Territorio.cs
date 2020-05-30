using System.Collections.Generic;

namespace NorthwindConsoleEF3.Modelos
{
    public class Territorio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        //Propriedade de navegação contendo a coleção de Empregados:
        public virtual ICollection<Empregado> Empregados { get; set; }
    }
}