using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models.DTOs
{
    public class UsuarioAuthLoginDTO
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string UsuarioA { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string Password { get; set; }
    }
}
