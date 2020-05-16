using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindConsoleEF3.Modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Nome { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Descricao { get; set; }

        //Propriedade de navegação 
        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            this.Produtos = new List<Produto>();
        }

    }
}
