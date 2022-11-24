using System;
using System.Collections.Generic;

namespace Sistemaprestamo1.Models
{
    public partial class CuentaBanco
    {
        public CuentaBanco()
        {
            CuotaInversions = new HashSet<CuotaInversion>();
        }

        public int IdBanco { get; set; }
        public string? Nombre { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
        public int? IdCliente { get; set; }
        public int? IdInversion { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Inversion? IdInversionNavigation { get; set; }
        public virtual ICollection<CuotaInversion> CuotaInversions { get; set; }
    }
}
