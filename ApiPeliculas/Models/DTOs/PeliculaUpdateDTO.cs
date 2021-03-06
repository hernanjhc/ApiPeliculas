using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ApiPeliculas.Models.Pelicula;

namespace ApiPeliculas.Models.DTOs
{
    public class PeliculaUpdateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Duracion { get; set; }
        public TipoClasificacion Clasificacion { get; set; }

        //relacion con categoria
        public int categoriaId { get; set; }
    }
}
