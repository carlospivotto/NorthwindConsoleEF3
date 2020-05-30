using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using NorthwindConsoleEF3.Modelos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Console;

namespace NorthwindConsoleEF3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarProdutosPorCategoria(false);
        }

        private static void ListarCategorias(bool eagerLoading)
        {
            using var db = new NorthwindDb();
            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new ConsoleLoggerProvider());
            WriteLine("Categorias:");
            IQueryable<Categoria> categorias = db.Categorias;
            if (eagerLoading)
            {
                categorias = db.Categorias.Include(c => c.Produtos);
            }
            foreach (var c in categorias)
            {
                WriteLine($"- {c.Nome}");
            }
        }

        private static void ConsultarProdutosPorCategoria(bool eagerLoading)
        {
            using var db = new NorthwindDb();
            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new ConsoleLoggerProvider());
            WriteLine("Categorias e quantos produtos possuem:");
            //Uma consulta que recupera todas as categorias
            //e, para cada categoria, seus produtos relacionados:
            IQueryable<Categoria> categorias = db.Categorias; //Usa LazyLoading se o Proxy estiver configurado.
            if (eagerLoading)
            {
                categorias = db.Categorias.Include(c => c.Produtos);
            }
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

        private static bool AdicionarProduto(string nomeProduto, decimal? preco, int categoriaId)
        {
            using var db = new NorthwindDb();
            var produto = new Produto
            {
                Nome = nomeProduto,
                Preco = preco,
                CategoriaId = categoriaId
            };

            // Marcar este produto como ADICIONADO no change tracker:
            db.Produtos.Add(produto);
            // Persistir mudanças no BD:
            int affected = db.SaveChanges();
            return (affected == 1);
        }

        private static void ListarProdutos()
        {
            using var db = new NorthwindDb();
            WriteLine("{0,-3} {1,-40} {2,10} {3,5} {4}", "ID", "Produto", "Preço", "Estoque", "Descontinuado");
            var produtos = db.Produtos.OrderBy(p => p.Nome);
            foreach (var p in produtos)
            {
                WriteLine("{0:000} {1,-40} {2,10:R$#,##0.00} {3:00000} {4}", p.ProdutoId, p.Nome, p.Preco, p.Estoque, p.Descontinuado);
            }
        }

        private static bool AjustarPrecoProduto(string nome, decimal valor)
        {
            using var db = new NorthwindDb();
            int affectedCount = 1;
            //Recuperar o primeiro produto que atender ao nome especificado e atualizar seu preço:
            /*var produto = db.Produtos.First(p => p.Nome.StartsWith(nome));
            produto.Preco += valor;*/

            var produtos = db.Produtos.Where(p => p.Nome.StartsWith(nome));
            foreach (var p in produtos)
            {
                p.Preco += valor;
                affectedCount++;
            }

            int affected = db.SaveChanges();
            return (affected == affectedCount);
        }

        private static int ExcluirProdutos(string nome)
        {
            using var db = new NorthwindDb();
            var produtos = db.Produtos.Where(p => p.Nome.StartsWith(nome));
            db.RemoveRange(produtos);
            int affected = db.SaveChanges();
            return affected;
        }


    }
}
