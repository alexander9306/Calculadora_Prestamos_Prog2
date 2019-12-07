using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora_Prestamos.Entidades
{
    public class Detalle_Prestamo
    {
        [Key]
        [Required]
        public int Detalle_PrestamoID { get; set; }
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
