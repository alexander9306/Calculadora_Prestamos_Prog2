namespace CalculosPrestamos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        indentificacion = c.String(nullable: false),
                        FechaNacimiennto = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.DetallesPrestamo",
                c => new
                    {
                        DetallesPrestamosID = c.Int(nullable: false, identity: true),
                        PrestamoID = c.Int(nullable: false),
                        FechaPago = c.DateTime(nullable: false),
                        SaldoInicial = c.Double(nullable: false),
                        Cuotas = c.Double(nullable: false),
                        Avances = c.Double(nullable: false),
                        PagoTotal = c.Double(nullable: false),
                        Capital = c.Double(nullable: false),
                        Interes = c.Double(nullable: false),
                        BalanceFinal = c.Double(nullable: false),
                        InteresAcumulado = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesPrestamosID)
                .ForeignKey("dbo.Prestamo", t => t.PrestamoID, cascadeDelete: true)
                .Index(t => t.PrestamoID);
            
            CreateTable(
                "dbo.Prestamo",
                c => new
                    {
                        PrestamoID = c.Int(nullable: false, identity: true),
                        MontoPrestamo = c.Double(nullable: false),
                        InteresAnual = c.Double(nullable: false),
                        PrediodoPrestamosAnnos = c.Int(nullable: false),
                        NumeroPagosAnno = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        PagosAdicionales = c.Double(nullable: false),
                        UsuarioNombre = c.String(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrestamoID)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Contrasena = c.String(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesPrestamo", "PrestamoID", "dbo.Prestamo");
            DropForeignKey("dbo.Prestamo", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Prestamo", new[] { "ClienteId" });
            DropIndex("dbo.DetallesPrestamo", new[] { "PrestamoID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Prestamo");
            DropTable("dbo.DetallesPrestamo");
            DropTable("dbo.Cliente");
        }
    }
}
