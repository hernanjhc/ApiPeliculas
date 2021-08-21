using ApiPeliculas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        //DbSet se requiere para crear las tablas...
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }

        
    }
}
