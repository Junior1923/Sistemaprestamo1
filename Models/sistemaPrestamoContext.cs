using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistemaprestamo1.Models
{
    public partial class sistemaPrestamoContext : DbContext
    {
        public sistemaPrestamoContext()
        {
        }

        public sistemaPrestamoContext(DbContextOptions<sistemaPrestamoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CuentaBanco> CuentaBancos { get; set; } = null!;
        public virtual DbSet<CuotaInversion> CuotaInversions { get; set; } = null!;
        public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; } = null!;
        public virtual DbSet<Garantium> Garantia { get; set; } = null!;
        public virtual DbSet<Inversion> Inversions { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS01; Database=sistemaPrestamo; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__677F38F5FF5E80E0");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<CuentaBanco>(entity =>
            {
                entity.HasKey(e => e.IdBanco)
                    .HasName("PK__CuentaBa__70BD1642598151AF");

                entity.ToTable("CuentaBanco");

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdInversion).HasColumnName("id_inversion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Numero)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CuentaBancos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Fk_Banco_id_cliente");

                entity.HasOne(d => d.IdInversionNavigation)
                    .WithMany(p => p.CuentaBancos)
                    .HasForeignKey(d => d.IdInversion)
                    .HasConstraintName("FK_CuentaBanco_id_inversion");
            });

            modelBuilder.Entity<CuotaInversion>(entity =>
            {
                entity.HasKey(e => e.IdCuotaIn)
                    .HasName("PK__CuotaInv__3670795D4EB64AAB");

                entity.ToTable("CuotaInversion");

                entity.Property(e => e.IdCuotaIn).HasColumnName("id_cuotaIn");

                entity.Property(e => e.CodigoComprobante).HasColumnName("codigoComprobante");

                entity.Property(e => e.FechaRealizado)
                    .HasColumnType("date")
                    .HasColumnName("fechaRealizado");

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.IdInversion).HasColumnName("id_inversion");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.CuotaInversions)
                    .HasForeignKey(d => d.IdBanco)
                    .HasConstraintName("FK_CuotaInversion_id_banco");

                entity.HasOne(d => d.IdInversionNavigation)
                    .WithMany(p => p.CuotaInversions)
                    .HasForeignKey(d => d.IdInversion)
                    .HasConstraintName("FK_Cuota_id_inversion");
            });

            modelBuilder.Entity<CuotaPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdCuotaPre)
                    .HasName("PK__cuotaPre__6B44768BE855B262");

                entity.ToTable("cuotaPrestamo");

                entity.Property(e => e.IdCuotaPre).HasColumnName("id_cuotaPre");

                entity.Property(e => e.CodigoComprobante).HasColumnName("codigoComprobante");

                entity.Property(e => e.FechaRealizado)
                    .HasColumnType("date")
                    .HasColumnName("fechaRealizado");

                entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.CuotaPrestamos)
                    .HasForeignKey(d => d.IdPrestamo)
                    .HasConstraintName("FK_cuaota_id_prestamo");
            });

            modelBuilder.Entity<Garantium>(entity =>
            {
                entity.HasKey(e => e.IdGarantia)
                    .HasName("PK__garantia__63A683D45ECBFD9F");

                entity.ToTable("garantia");

                entity.Property(e => e.IdGarantia).HasColumnName("id_garantia");

                entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.Garantia)
                    .HasForeignKey(d => d.IdPrestamo)
                    .HasConstraintName("Fk_garantia_id_prestamo");
            });

            modelBuilder.Entity<Inversion>(entity =>
            {
                entity.HasKey(e => e.IdInversion)
                    .HasName("PK__inversio__F5B400486C5E7E08");

                entity.ToTable("inversion");

                entity.Property(e => e.IdInversion).HasColumnName("id_inversion");

                entity.Property(e => e.FechaBeg)
                    .HasColumnType("date")
                    .HasColumnName("fechaBeg");

                entity.Property(e => e.FechaEnd)
                    .HasColumnType("date")
                    .HasColumnName("fechaEnd");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Interes).HasColumnName("interes");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Inversions)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_inversion_id_cliente");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PK__Prestamo__5E87BE27E84D759E");

                entity.ToTable("Prestamo");

                entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");

                entity.Property(e => e.FechaBeg)
                    .HasColumnType("date")
                    .HasColumnName("fechaBeg");

                entity.Property(e => e.FechaEnd)
                    .HasColumnType("date")
                    .HasColumnName("fechaEnd");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdFiador).HasColumnName("id_fiador");

                entity.Property(e => e.Interes)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("interes");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_prestamo_id_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
