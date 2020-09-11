using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Producto
    {
        public int idProducto { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categoría")]
        public int idCategoria { get; set; }

        [StringLength(64,
            ErrorMessage ="El código no debe tener más de 64 caractéres.")]
        [Display(Name = "Código")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage ="El nombre no debe tener más de 100 caractéres, ni menos de 3")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Precio de venta")]
        public decimal precioVenta { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Stock")]
        public int stock { get; set; }

        [StringLength(255,
            ErrorMessage = "La descripción no debe tener más de 255 caractéres.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool? estado { get; set; }

        [Display(Name = "Categoria")]
        public virtual Categoria categoria { get; set; }
    }
}
