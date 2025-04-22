using System.Data;
using System.Data.Common;
using Dapper;
using ejercicio_dapper.Data.Modelos;

namespace ejercicio_dapper.Data.Dapper
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            const string query = "SELECT * FROM Productos";
            return await _dbConnection.QueryAsync<Producto>(query);
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM Productos WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Producto>(query, new { Id = id });
        }

        public async Task<Producto> AddAsync(Producto producto)
        {
            const string query = @"
                INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Activo) 
                OUTPUT INSERTED.*
                VALUES (@Nombre,@Descripcion,@Precio, @Stock, @Activo)";

            return await _dbConnection.QuerySingleAsync<Producto>(query, producto);
        }

        public async Task UpdateAsync(Producto producto)
        {
            const string query = @"
                UPDATE Productos 
                SET Nombre = @Nombre, 
                    Precio = @Precio, 
                    Stock = @Stock 
                WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(query, producto);
        }

        public async Task DeleteAsync(int id)
        {
            const string query = "DELETE FROM Productos WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<bool> ExistsAsync(int id)
        {
            const string query = "SELECT 1 FROM Productos WHERE Id = @Id";
            var exists = await _dbConnection.ExecuteScalarAsync<bool>(query, new { Id = id });
            return exists;
        } 

    }
}
