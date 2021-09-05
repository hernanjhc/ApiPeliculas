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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _repoUsuario;

        public UsuariosController(IUsuarioRepository repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UsuarioU() { });
        }

        [HttpGet]
        public async Task<IActionResult> GetTodosUsuarios()
        {
            return Json( 
                new { data = await _repoUsuario.GetTodoAsync(CT.RutaUsuariosApi)}
                );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Create(UsuarioU Usuario)
        {
            if (ModelState.IsValid)
            {
                await _repoUsuario.CrearAsync(CT.RutaUsuariosApi, Usuario,
                    HttpContext.Session.GetString("JWToken"));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Edit(int? id)
        {
            UsuarioU itemUsuario = new UsuarioU();

            if (id==null)
            {
                return NotFound();
            }

            itemUsuario = await _repoUsuario.GetAsync(CT.RutaUsuariosApi, id.GetValueOrDefault());
            if (itemUsuario == null)
            {
                return NotFound();
            }

            return View(itemUsuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Controla que esta peticion llegue desde el form Create
        public async Task<IActionResult> Update(UsuarioU Usuario)
        {
            if (ModelState.IsValid)
            {
                await _repoUsuario.ActualizarAsync(CT.RutaUsuariosApi + Usuario.Id, Usuario,
                    HttpContext.Session.GetString("JWToken"));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _repoUsuario.BorrarAsync(CT.RutaUsuariosApi, id,
                    HttpContext.Session.GetString("JWToken"));

            if (status)
            {
                return Json(new { success = true, message = "Borado correctamente" });
            }

            return Json(new { success = false, message = "No se pudo borar" });
        }
    }
}
