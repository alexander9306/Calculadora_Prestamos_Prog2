using CalculosPrestamos.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CalculosPrestamos.DAL
{
    public class CalculosPrestamosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CalculosPrestamosContext() : base("name=CalculosPrestamosContext")
        {
            Database.SetInitializer( new DatosInitializer());
        }

        public System.Data.Entity.DbSet<CalculosPrestamos.Models.Usuario> Usuario { get; set; }

        public System.Data.Entity.DbSet<CalculosPrestamos.Models.Cliente> Cliente { get; set; }

        public System.Data.Entity.DbSet<CalculosPrestamos.Models.Prestamo> Prestamo { get; set; }

        public System.Data.Entity.DbSet<CalculosPrestamos.Models.DetallesPrestamo> DetallesPrestamo { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
