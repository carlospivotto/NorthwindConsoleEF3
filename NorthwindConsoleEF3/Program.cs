using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using NorthwindConsoleEF3.Modelos;
using System.Linq;
using static System.Console;

namespace NorthwindConsoleEF3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarProdutos();
        }

        private static void ConsultarCategorias()
        {
            using var db = new NorthwindDb();
            WriteLine("Categorias e quantos produtos possuem:");
            //Uma consulta que recupera todas as categorias
            //e, para cada categoria, seus produtos relacionados:
            IQueryable<Categoria> categorias = db.Categorias.Include(c => c.Produtos);
            foreach (var c in categorias)
            {
                WriteLine($"{c.Nome} possui {c.Produtos.Count} produtos.");
                foreach (var p in c.Produtos)
                {
                    WriteLine($" — {p.Nome} ({p.Estoque} unidades no estoque)");
                }
            }
        }

        private static void ConsultarProdutos()
        {
            using var db = new NorthwindDb();
            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new ConsoleLoggerProvider());
            WriteLine("Produtos que custam mais do que um determinado preço, do mais caro para o mais barato:");
            string input;
            decimal preco;
            do
            {
                Write("Informe um preço: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out preco));

            IOrderedEnumerable<Produto> produtos = db.Produtos.AsEnumerable()   // Carregue todos os produtos, como um enumerável
                .Where(p => p.Preco > preco)                                    // onde o preço do produto é maior que preco
                .OrderByDescending(p => p.Preco);                               // Em ordem decrescente de preço

            foreach (var p in produtos)
            {
                WriteLine("{0}: {1} custa {2:R$#,##0.00} e possui {3} unidades em estoque.", p.ProdutoId, p.Nome, p.Preco, p.Estoque);
            }
        }
    }
}
