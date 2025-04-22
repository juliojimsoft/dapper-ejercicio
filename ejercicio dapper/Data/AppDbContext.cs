using ejercicio_dapper.Data.Modelos;
using ejercicio_dapper.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace ejercicio_dapper.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración adicional (opcional)
            modelBuilder.Entity<Producto>(entity =>
            {
                // Índice único
                entity.HasIndex(p => p.Nombre).IsUnique();
                entity.Property(p => p.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });


            // Sembrar datos iniciales
            modelBuilder.Entity<Producto>().HasData(ProductoSeed.GetProductos());
        }

        public DbSet<Producto> Productos { get; set; } = null!;
    }
}
