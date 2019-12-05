using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Monto del préstamo")]
        public double MontoPrestamo { get; set; }
        [Required]
        [Display(Name = "Interés Annual")]
        public double InteresAnual { get; set; }
        [Required]
        [Display(Name = "Período de préstamos por año")]
        public int PrediodoPrestamosAnnos { get; set; }
        [Required]
        [Display(Name = "Número de pagos al año")]
        public int NumeroPagosAnno { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Pagos Adicionales")]
        public double PagosAdicionales { get; set; }
        [Required]
        [Display(Name = "Atendido por: ")]
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        [Index(IsUnique = true)]
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
        [Display(Name = "Fecha de pago")]
        public DateTime FechaPago { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Saldo Inicial")]
        public double SaldoInicial { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cuotas")]
        public double Cuotas { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Avances")]
        public double Avances { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Pago Total")]
        public double PagoTotal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Capital")]
        public double Capital { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Interés")]
        public double Interes { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Balance Final")]
        public double BalanceFinal { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Interés Acumulado")]
        public double InteresAcumulado { get; set; }

    }
}