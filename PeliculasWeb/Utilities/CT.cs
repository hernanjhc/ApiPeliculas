using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Utilities
{
    public static class CT
    {
        //crear rutas static
        public static string UrlBaseApi = "https://localhost:44325/";
        public static string RutaCategoriasApi = UrlBaseApi + "api/Categorias/";
        public static string RutaPeliculasApi = UrlBaseApi + "api/Peliculas/";
        public static string RutaUsuariosApi = UrlBaseApi + "api/Usuarios/";

        //Faltan más rutas
    }
}
