using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora_Prestamos.Entidades
{
    public class Cliente
    {
        [Required]
        [Key]
        public int ClienteID { get; set; }
        [Required]
        [Display(Name = "Nombre del Cliente")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Cédula/pasaporte")]
        public string indentificacion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiennto { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }
    }
}
