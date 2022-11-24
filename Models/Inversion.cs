using System;
using System.Collections.Generic;

namespace Sistemaprestamo1.Models
{
    public partial class Inversion
    {
        public Inversion()
        {
            CuentaBancos = new HashSet<CuentaBanco>();
            CuotaInversions = new HashSet<CuotaInversion>();
        }

        public int IdInversion { get; set; }
        public int? IdCliente { get; set; }
        public double? Monto { get; set; }
        public DateTime? FechaBeg { get; set; }
        public DateTime? FechaEnd { get; set; }
        public double? Interes { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<CuentaBanco> CuentaBancos { get; set; }
        public virtual ICollection<CuotaInversion> CuotaInversions { get; set; }
    }
}
