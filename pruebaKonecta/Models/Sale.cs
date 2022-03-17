using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pruebaKonecta.Models
{
    public partial class Sale
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El producto es obligatorio")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        public DateTime? FechaVenta { get; set; }
    }
}
