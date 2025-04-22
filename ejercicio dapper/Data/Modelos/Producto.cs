using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio_dapper.Data.Modelos
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }


        public int Stock { get; set; }

        [Column(TypeName ="decimal(18,4)")]
        public decimal Precio { get; set; }
        
        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; } = true;
    }
}
