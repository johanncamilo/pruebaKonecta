using System;
using System.Collections.Generic;

namespace pruebaKonecta.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public int Peso { get; set; }
        public string Categoria { get; set; } = null!;
        public int Stock { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
