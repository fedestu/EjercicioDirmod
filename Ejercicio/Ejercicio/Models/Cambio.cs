using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Models
{
    public class Cambio
    {
        [Key]
        public string Moneda { get; set; }

        public double Precio { get; set; }

        public int Cantidad { get; set; }

        public double PrecioCambio { get; set; }
    }
}
