using System;
using System.Collections.Generic;

namespace Sistemaprestamo1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CuentaBancos = new HashSet<CuentaBanco>();
            Inversions = new HashSet<Inversion>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdCliente { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<CuentaBanco> CuentaBancos { get; set; }
        public virtual ICollection<Inversion> Inversions { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
