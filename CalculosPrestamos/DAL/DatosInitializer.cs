using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculosPrestamos.DAL
{
    public class DatosInitializer: System.Data.Entity.CreateDatabaseIfNotExists<CalculosPrestamosContext>
    {
        protected override void Seed(CalculosPrestamosContext context)
        {
            base.Seed(context); 
        }
    }
}