using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pruebaQuala.Models
{
    public partial class TestDBContext : DbContext
    {
       
        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventarios> Inventarios { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }

              protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventarios>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK_INVENTARIO");

                entity.ToTable("INVENTARIOS");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(250);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(250);

                entity.Property(e => e.Fechacreacion)
                    .HasColumnName("FECHACREACION")
                    .HasMaxLength(50);

                entity.Property(e => e.Idmoneda).HasColumnName("IDMONEDA");

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasColumnName("SUCURSAL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.Idmoneda);

                entity.ToTable("MONEDA");

                entity.Property(e => e.Idmoneda).HasColumnName("IDMONEDA");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
