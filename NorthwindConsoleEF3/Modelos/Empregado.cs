namespace NorthwindConsoleEF3.Modelos
{
    public class Empregado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        //Propriedade de navegação de Empregado para CartaoAcesso
        public CartaoAcesso CartaoAcesso { get; set; }
    }
}