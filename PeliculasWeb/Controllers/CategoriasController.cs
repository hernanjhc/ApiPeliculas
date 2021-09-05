using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _repoCategoria.CrearAsync(CT.RutaCategoriasApi, categoria,
                    HttpContext.Session.GetString("JWToken"));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Edit(int? id)
        {
            Categoria itemCategoria = new Categoria();

            if (id==null)
            {
                return NotFound();
            }

            itemCategoria = await _repoCategoria.GetAsync(CT.RutaCategoriasApi, id.GetValueOrDefault());
            if (itemCategoria == null)
            {
                return NotFound();
            }

            return View(itemCategoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Update(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _repoCategoria.ActualizarAsync(CT.RutaCategoriasApi + categoria.Id, categoria,
                    HttpContext.Session.GetString("JWToken"));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _repoCategoria.BorrarAsync(CT.RutaCategoriasApi, id,
                    HttpContext.Session.GetString("JWToken"));

            if (status)
            {
                return Json(new { success = true, message = "Boraddo correctamente" });
            }

            return Json(new { success = false, message = "No se pudo borar" });
        }
    }
}
