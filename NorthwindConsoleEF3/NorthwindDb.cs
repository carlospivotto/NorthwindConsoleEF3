using Microsoft.EntityFrameworkCore;
using NorthwindConsoleEF3.Modelos;

namespace NorthwindConsoleEF3
{
    public class NorthwindDb : DbContext
    {
        // Mapear tabelas:
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=NorthwindEF3;MultipleActiveResultSets=true;" +
                "Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(categoria => categoria.Nome)
                .IsRequired(); // NOT NULL
        }
    }
}
