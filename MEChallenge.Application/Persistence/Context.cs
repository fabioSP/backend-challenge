using MEChallenge.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MEChallenge.Application.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {  }

        public DbSet<PedidoMO> Pedido { get; set; }
        public DbSet<ProdutoMO> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoMO>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PedidoMO>()
            .HasKey(c => new { c.Id, c.IdProduto });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
