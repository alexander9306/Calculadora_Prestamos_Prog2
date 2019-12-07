using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora_Prestamos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calculadora_Prestamos.Datos.Mapping
{
    public class PrestamoMap : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.ToTable("prestamo")
                .HasKey(p => p.PrestamoID);
                builder.HasIndex(p => p.ClienteId)
                .IsUnique();
        }
    }
}
