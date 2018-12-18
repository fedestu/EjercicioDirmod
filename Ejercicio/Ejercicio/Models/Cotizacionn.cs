using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Models
{
    public class Cotizacionn
    {
        [Key]
        public string Moneda { get; set; }

        public double Precio { get; set; }
    }
}
