using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        
        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "El nombre no debe de tener más de 50 caractéres, ni menos de 3.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [StringLength(255,
            ErrorMessage = "La descripción no debe tener más de 255 caractéres.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool? estado { get; set; }
        public ICollection<Producto> productos { get; set; }
        

    }
}
