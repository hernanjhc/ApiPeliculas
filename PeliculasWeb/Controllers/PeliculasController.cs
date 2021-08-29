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
    public class PeliculasController : Controller
    {
        private readonly IPeliculaRepository _repoPelicula;

        public PeliculasController(IPeliculaRepository repoPelicula)
        {
            _repoPelicula = repoPelicula;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Pelicula() { });
        }

        [HttpGet]
        public async Task<IActionResult> GetTodasPeliculas()
        {
            return Json( 
                new { data = await _repoPelicula.GetTodoAsync(CT.RutaPeliculasApi)}
                );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Create(Pelicula Pelicula)
        {
            if (ModelState.IsValid)
            {
                await _repoPelicula.CrearAsync(CT.RutaPeliculasApi, Pelicula);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Edit(int? id)
        {
            Pelicula itemPelicula = new Pelicula();

            if (id==null)
            {
                return NotFound();
            }

            itemPelicula = await _repoPelicula.GetAsync(CT.RutaPeliculasApi, id.GetValueOrDefault());
            if (itemPelicula == null)
            {
                return NotFound();
            }

            return View(itemPelicula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Update(Pelicula Pelicula)
        {
            if (ModelState.IsValid)
            {
                await _repoPelicula.ActualizarAsync(CT.RutaPeliculasApi + Pelicula.Id, Pelicula);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _repoPelicula.BorrarAsync(CT.RutaPeliculasApi, id);

            if (status)
            {
                return Json(new { success = true, message = "Boraddo correctamente" });
            }

            return Json(new { success = false, message = "No se pudo borar" });
        }
    }
}
