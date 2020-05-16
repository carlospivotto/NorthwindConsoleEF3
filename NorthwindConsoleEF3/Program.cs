using Microsoft.EntityFrameworkCore;
using NorthwindConsoleEF3.Modelos;
using System;
using System.Linq;
using static System.Console;

namespace NorthwindConsoleEF3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarCategorias();
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
    }
}
