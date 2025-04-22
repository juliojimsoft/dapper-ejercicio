using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Dapper;
using ejercicio_dapper.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;
using ejercicio_dapper.Data.Dapper;
using System.Data;

namespace ejercicio_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDbConnection _dbConnection;

        public DatabaseController(AppDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }

        [HttpGet("ProbarConexionEf")]
        public async Task<IActionResult> ProbarConexion()
        {
            try
            {
                // probar conexion con entity framework
                var connectionSuccesEf = await _context.Database.CanConnectAsync();
                if (!connectionSuccesEf)
                {
                    return BadRequest("Error: EF Core no puede conectarse a la base de datos");
                }

                return Ok($"Conexión exitosa. Base de datos: {_context.Database.GetDbConnection().Database}");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        [HttpGet("ProbarConexionDapper")]
        public async Task<IActionResult> TestDapper()
        {
            try
            {
                var dbName = await _dbConnection.ExecuteScalarAsync<string>("SELECT DB_NAME()");
                return Ok($"Conexión exitosa. Base de datos: {dbName}");
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            };
        }
    }
}
