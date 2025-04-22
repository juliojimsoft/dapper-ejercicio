using System.ComponentModel.DataAnnotations;

namespace ejercicio_dapper.Data.DTO
{
    public class ProductoDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(255, ErrorMessage = "La descripción no puede exceder 255 caracteres")]
        public string Descripcion { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
    }
}
