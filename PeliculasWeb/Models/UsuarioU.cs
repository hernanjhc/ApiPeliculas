using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Models
{
    public class UsuarioU
    {
        public int Id { get; set; }
        public string UsuarioA { get; set; }
        //aplica hash al password y guarda passw encriptado
        public string PasswordHash { get; set; }
    }
}
