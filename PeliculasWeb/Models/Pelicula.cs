using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }
        public byte[] RutaImagen { get; set; }  //en sql es varbinary(MAX)
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Dieciocho }
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        //relacion con categoria
        public int categoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
