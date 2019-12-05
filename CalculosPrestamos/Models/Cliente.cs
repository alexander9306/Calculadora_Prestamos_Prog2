using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculosPrestamos.Models
{
    public class Cliente
    {
        [Required]
        [Key]
        public int ClienteID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [CreditCard]
        public string indentificacion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiennto { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        [Phone]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }
    }
}