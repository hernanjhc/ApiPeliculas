using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models.DTOs
{
    public class UsuarioAuthDTO
    {
        //para dar de alta usuarios
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El usuario es obligatorio.")]
        public string UsuarioA { get; set; }
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [StringLength(10,MinimumLength =4,ErrorMessage ="Requiere entre 4 y 10 caracteres.")]
        public string Password { get; set; }
    }
}
