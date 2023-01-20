using System;
using System.Collections.Generic;

namespace pruebaQuala.Models
{
    public partial class Inventarios
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Sucursal { get; set; }
        public string? Fechacreacion { get; set; }
        public int Idmoneda { get; set; }
    }
}
