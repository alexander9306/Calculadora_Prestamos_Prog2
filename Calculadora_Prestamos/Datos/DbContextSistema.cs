using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora_Prestamos.Datos.Mapping;
using Calculadora_Prestamos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Calculadora_Prestamos.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Detalle_Prestamo> Detalle_Prestamos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new Detalle_PrestamoMap());
            modelBuilder.ApplyConfiguration(new PrestamoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
