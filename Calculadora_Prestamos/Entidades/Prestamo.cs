using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora_Prestamos.Entidades
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
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<Detalle_Prestamo> Detalle_Prestamo { get; set; }
    }
}
