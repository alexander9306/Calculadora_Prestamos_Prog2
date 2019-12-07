using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculadora_Prestamos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    indentificacion = table.Column<string>(nullable: false),
                    FechaNacimiennto = table.Column<DateTime>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Salario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "prestamo",
                columns: table => new
                {
                    PrestamoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MontoPrestamo = table.Column<double>(nullable: false),
                    InteresAnual = table.Column<double>(nullable: false),
                    PrediodoPrestamosAnnos = table.Column<int>(nullable: false),
                    NumeroPagosAnno = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    PagosAdicionales = table.Column<double>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamo", x => x.PrestamoID);
                    table.ForeignKey(
                        name: "FK_prestamo_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prestamo_usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_prestamo",
                columns: table => new
                {
                    Detalle_PrestamoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrestamoID = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    SaldoInicial = table.Column<double>(nullable: false),
                    Cuotas = table.Column<double>(nullable: false),
                    Avances = table.Column<double>(nullable: false),
                    PagoTotal = table.Column<double>(nullable: false),
                    Capital = table.Column<double>(nullable: false),
                    Interes = table.Column<double>(nullable: false),
                    BalanceFinal = table.Column<double>(nullable: false),
                    InteresAcumulado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_prestamo", x => x.Detalle_PrestamoID);
                    table.ForeignKey(
                        name: "FK_detalle_prestamo_prestamo_PrestamoID",
                        column: x => x.PrestamoID,
                        principalTable: "prestamo",
                        principalColumn: "PrestamoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalle_prestamo_PrestamoID",
                table: "detalle_prestamo",
                column: "PrestamoID");

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_ClienteId",
                table: "prestamo",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prestamo_UsuarioID",
                table: "prestamo",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_prestamo");

            migrationBuilder.DropTable(
                name: "prestamo");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
