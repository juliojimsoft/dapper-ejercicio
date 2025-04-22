using ejercicio_dapper.Data.Modelos;

namespace ejercicio_dapper.Data.Seed
{
    public class ProductoSeed
    {
        public static List<Producto> GetProductos()
        {
            return new List<Producto>
            {
                new Producto
                {
                    Id = 1,
                    Nombre = "Laptop EliteBook",
                    Descripcion = "Core i7, 16GB RAM, 512GB SSD",
                    Precio = 1599.99m,
                    Stock = 10,
                    Activo = true
                },
                new Producto
                {
                     Id = 2,
                    Nombre = "Monitor 4K 27\"",
                    Descripcion = "IPS, HDR10, 99% sRGB",
                    Precio = 349.50m,
                    Stock = 25,
                    Activo = true
                },
                new Producto
                {
                     Id = 3,
                    Nombre = "Teclado mecánico RGB",
                    Descripcion = "Switches Blue, retroiluminado",
                    Precio = 89.99m,
                    Stock = 40,
                    Activo = true
                }
            };
        }
    }
}
