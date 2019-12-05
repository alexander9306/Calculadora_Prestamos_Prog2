using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculosPrestamos.Models
{
    public class Prestamo
    {
        [Key]
        [Required]
        public int PrestamoID { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double MontoPrestamo { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double InteresAnual { get; set; }
        [Required]
        public int PrediodoPrestamosAnnos { get; set; }
        [Required]
        public int NumeroPagosAnno { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double PagosAdicionales { get; set; }
        [Required]
        public string UsuarioNombre { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<DetallesPrestamo> DetallesPrestamos { get; set; }
    }

    public class DetallesPrestamo
    {
        [Key]
        [Required]
        public int DetallesPrestamosID { get; set; }
        [Required]
        public int PrestamoID { get; set; }
        public virtual Prestamo Prestamo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double SaldoInicial { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Cuotas { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Avances { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double PagoTotal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Capital { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Interes { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double BalanceFinal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double InteresAcumulado { get; set; }

    }
}