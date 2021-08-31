using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Models.ViewModels
{
    public class PeliculasVM
    {
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
