using System.ComponentModel.DataAnnotations;

namespace pruebaKonecta.Models.ViewModels
{
    public class ProductViewModel
    {        
        [Required]        
        public string Nombre { get; set; }

        [Required]        
        public int Precio { get; set; }
        [Required]        
        public int Peso { get; set; }
        [Required]        
        public string Categoria { get; set; }
        [Required]        
        public int Stock { get; set; }

    }
}
