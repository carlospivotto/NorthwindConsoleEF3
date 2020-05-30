using Microsoft.EntityFrameworkCore;
using NorthwindConsoleEF3.Modelos;
using Microsoft.EntityFrameworkCore.Proxies;

namespace NorthwindConsoleEF3
{
    public class NorthwindDb : DbContext
    {
        // Mapear tabelas:
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Territorio> Territorios { get; set; }

        //Embora Fornecedor não esteja mapeado explicitamente como um DbSet<>, 
        //Produtos depende de seu mapeamento, que é portanto providenciado internamente.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=NorthwindEF3;MultipleActiveResultSets=true;" +
                "Trusted_Connection=true;";

            //Chamar o método .UseLazyLoadingProxies() ANTES do método UseSqlServer(connectionString)
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(categoria => categoria.Nome)
                .IsRequired(); // NOT NULL

            //Fornecedor e Empregado terão tabelas com nomes criados no singular, 
            // por não serem explicitamente mapeados.
            // Poderíamos mapeá-los explicitamente, ou...
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedores");
            modelBuilder.Entity<Empregado>().ToTable("Empregados");

            //Caso não seja possível seguir as convenções,
            // ainda é possível manualmente configurar uma relação.
            modelBuilder.Entity<Pedido>()           // Um Pedido
                .HasOne<Cliente>(p => p.Cliente)    // possui um Cliente
                .WithMany(c => c.Pedidos)           // com muitos Pedidos
                .HasForeignKey(p => p.ClienteId);   // e pedido terá FK ClienteId

            //Como Cliente e Pedido não estão explicitamente mapeadas como propriedades,
            // precisamos explicitamente pluralizar seus nomes de tabela
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            //Configuração de uma relação um para um:
            modelBuilder.Entity<Empregado>()                        // Um Empregado
                .HasOne<CartaoAcesso>(e => e.CartaoAcesso)          // possui um CartaoAcesso
                .WithOne(ca => ca.Empregado)                        // com um Empregado
                .HasForeignKey<CartaoAcesso>(ca => ca.EmpregadoId); // e esta FK


            //Configuração da chave primária de DetalhamentoPedido:
            modelBuilder.Entity<DetalhamentoPedido>()
                .HasKey(dp => new { dp.PedidoId, dp.ProdutoId });

            //Poderíamos configurar manualmente as duas relações um para muitos 
            //Note que o que não existe é uma convenção nxn.
            //Mas nós utilizamos as convenções 1xn duas vezes.
            //Assim, essas duas próximas operações não seriam necessárias.
            //(Mas são uma alternativa)
            modelBuilder.Entity<DetalhamentoPedido>()
                .HasOne<Pedido>(dp => dp.Pedido)
                .WithMany(pedido => pedido.ProdutosPedido)
                .HasForeignKey(dp => dp.PedidoId);

            modelBuilder.Entity<DetalhamentoPedido>()
                .HasOne<Produto>(dp => dp.Produto)
                .WithMany(produto => produto.PedidosProduto)
                .HasForeignKey(dp => dp.ProdutoId);

            //Pluralização do nome da tabela:
            modelBuilder.Entity<DetalhamentoPedido>().ToTable("DetalhamentoPedidos");
        }
    }
}