using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculosPrestamos.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
        [Required]
        [Display(Name = "Estado [Activo/Inactivo]")]
        public bool Estado { get; set; }
    }
}