using ejercicio_dapper.Data.Modelos;

namespace ejercicio_dapper.Data.Dapper
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<Producto> AddAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
