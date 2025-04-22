using System.Data;
using Microsoft.Data.SqlClient;

namespace ejercicio_dapper.Data.Dapper
{
    public class DapperRepository
    {
        // almacena la cadena de conexion a la base de datos
        private readonly string _connectionString;

        /*constructor que recibe la configuracion de la aplicaicon*/
        public DapperRepository(IConfiguration configuration)
        {
            // Obtiene la cadena de conexión llamada "DefaultConnection" desde la configuración
            // Si no existe, lanza una excepción para evitar problemas en tiempo de ejecución
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("No se encontró 'DefaultConnection' en la configuración.");
        }

        // Método que crea y devuelve una nueva conexión a la base de datos
        // Usa el tipo IDbConnection (interfaz genérica) en lugar de SqlConnection específico
        // para mayor flexibilidad y posibilidad de cambiar el proveedor de BD fácilmente
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
