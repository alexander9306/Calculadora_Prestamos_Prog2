using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora_Prestamos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calculadora_Prestamos.Datos.Mapping 
{
    public class Detalle_PrestamoMap : IEntityTypeConfiguration<Detalle_Prestamo>
    {
        public void Configure(EntityTypeBuilder<Detalle_Prestamo> builder)
        {
            builder.ToTable("detalle_prestamo")
                .HasKey(dp => dp.Detalle_PrestamoID);
        }
    }
}
