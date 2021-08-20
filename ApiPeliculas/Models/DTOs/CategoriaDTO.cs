using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models.DTOs
{
    public class CategoriaDTO
    {
        /*Objeto de transferencia de Datos*/
        //Se envía DTO por http en lugar del Modelo
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es olbigatorio.")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
