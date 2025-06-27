using Microsoft.EntityFrameworkCore;
using App.Models;
namespace App.Data

{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CodigoCategoria);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Producto)
                .WithMany(p => p.Ventas)
                .HasForeignKey(v => v.CodigoProducto);
        }
    }
}
