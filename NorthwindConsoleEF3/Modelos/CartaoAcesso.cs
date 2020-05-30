namespace NorthwindConsoleEF3.Modelos
{
    public class CartaoAcesso
    {
        public int Id { get; set; }
        public string Chave { get; set; }

        //Propriedade FK para Empregado
        public int EmpregadoId { get; set; }
        //Propriedade de navegação de CartaoAcesso para Empregado
        public virtual Empregado Empregado { get; set; }
    }
}