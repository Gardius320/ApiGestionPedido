using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;
using System.Security.Cryptography.X509Certificates;

namespace OrderManagement.Data
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) // ****investigar****
            : base(options) { }


        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoDetalle> PedidoDetalles => Set<PedidoDetalle>();
        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // investigar que hace esta linea
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
               
            });
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

            });
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);  
                entity.HasOne(e => e.Cliente)
                      .WithMany(c => c.Pedidos)
                      .HasForeignKey(e => e.ClienteId);

            });
            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Pedido)
                      .WithMany(p => p.PedidoDetalles)
                      .HasForeignKey(e => e.PedidoId);
                entity.HasOne(e => e.Producto)
                      .WithMany()
                      .HasForeignKey(e => e.ProductoId);

            });
        }

    }


}
