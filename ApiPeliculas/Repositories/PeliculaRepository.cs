using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly ApplicationDbContext _bd;

        public PeliculaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarPelicula(Pelicula pelicula)
        {
            _bd.Pelicula.Update(pelicula);
            return Guardar();
        }

        public bool BorrarPelicula(Pelicula pelicula)
        {
            _bd.Pelicula.Remove(pelicula);
            return Guardar();
        }

        public IEnumerable<Pelicula> BuscarPelicula(string nombre)
        {
            IQueryable<Pelicula> query = _bd.Pelicula;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(e => e.Nombre.Contains(nombre) || e.Descripcion.Contains(nombre));
            }

            return query.ToList();
        }

        public bool CrearPelicula(Pelicula pelicula)
        {
            _bd.Pelicula.Add(pelicula);
            return Guardar();
        }

        public bool ExistePelicula(string nombre)
        {
            bool valor = _bd.Pelicula.Any(p => p.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public bool ExistePelicula(int peliculaId)
        {
            return _bd.Pelicula.Any(p => p.Id == peliculaId);
        }

        public Pelicula GetPelicula(int peliculaId)
        {
            return _bd.Pelicula.Find(peliculaId);
        }

        public ICollection<Pelicula> GetPeliculas()
        {
            return _bd.Pelicula.OrderBy(p => p.Nombre).ToList();
        }

        public ICollection<Pelicula> GetPeliculasEnCategoria(int CatId)
        {
            return _bd.Pelicula.Include(ca => ca.Categoria).Where(p => p.categoriaId == CatId).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
