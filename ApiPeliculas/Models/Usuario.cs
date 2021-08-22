using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UsuarioA { get; set; }
        //aplica hash al password y guarda passw encriptado
        public byte[] PasswordHash { get; set; }
        //aplica salt al pass hasheado
        public byte[] PasswordSalt { get; set; }
    }
}
