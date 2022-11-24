using System;
using System.Collections.Generic;

namespace Sistemaprestamo1.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            CuotaPrestamos = new HashSet<CuotaPrestamo>();
            Garantia = new HashSet<Garantium>();
        }

        public int IdPrestamo { get; set; }
        public int? IdFiador { get; set; }
        public int? IdCliente { get; set; }
        public double? Monto { get; set; }
        public DateTime? FechaBeg { get; set; }
        public DateTime? FechaEnd { get; set; }
        public decimal? Interes { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; set; }
        public virtual ICollection<Garantium> Garantia { get; set; }
    }
}
