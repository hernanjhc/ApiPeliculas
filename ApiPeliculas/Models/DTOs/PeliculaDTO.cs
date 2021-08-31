using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ApiPeliculas.Models.Pelicula;

namespace ApiPeliculas.Models.DTOs
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio.")]
        public string Nombre { get; set; }
        public byte[] RutaImagen { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Duracion { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Dieciocho }
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        //relacion con categoria
        public int categoriaId { get; set; }
        [ForeignKey("categoriaId")]
        public Categoria Categoria { get; set; }
    }
}
