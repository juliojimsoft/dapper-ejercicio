using ejercicio_dapper.Data.Dapper;
using ejercicio_dapper.Data.DTO;
using ejercicio_dapper.Data.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ejercicio_dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoRepository.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return NotFound();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id) return BadRequest("Id mismatch");

            if (!await _productoRepository.ExistsAsync(id)) return NotFound();
            
            await _productoRepository.UpdateAsync(producto);

            var productoActualizado = await _productoRepository.GetByIdAsync(id);
            return Ok(productoActualizado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDto productoDto)
        {
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock,
                Activo = true, // Valor por defecto
            };

            var productoInsertado = await _productoRepository.AddAsync(producto);
            return Ok(productoInsertado);
        }

    }
}
