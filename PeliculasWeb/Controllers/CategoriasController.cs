using Microsoft.AspNetCore.Mvc;
using PeliculasWeb.Models;
using PeliculasWeb.Repositories.IRepositories;
using PeliculasWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasWeb.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _repoCategoria;

        public CategoriasController(ICategoriaRepository repoCategoria)
        {
            _repoCategoria = repoCategoria;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Categoria() { });
        }

        [HttpGet]
        public async Task<IActionResult> GetTodasCategorias()
        {
            return Json( 
                new { data = await _repoCategoria.GetTodoAsync(CT.RutaCategoriasApi)}
                );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
