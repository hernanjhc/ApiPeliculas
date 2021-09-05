using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeliculasWeb.Models;
using PeliculasWeb.Models.ViewModels;
using PeliculasWeb.Repositories.IRepositories;
using PeliculasWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PeliculasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _repoAccount;
        private readonly IPeliculaRepository _repoPelicula;
        private readonly ICategoriaRepository _repoCategoria;

        public HomeController(ILogger<HomeController> logger, IAccountRepository repoAccount, 
            IPeliculaRepository repoPelicula, ICategoriaRepository repoCategoria)
        {
            _logger = logger;
            _repoAccount = repoAccount;
            _repoPelicula = repoPelicula;
            _repoCategoria = repoCategoria;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM listaPeliculasCategorias = new IndexVM()
            {
                ListaCategorias = (IEnumerable<Categoria>)await _repoCategoria.GetTodoAsync(CT.RutaCategoriasApi),
                ListaPeliculas = (IEnumerable<Pelicula>)await _repoPelicula.GetTodoAsync(CT.RutaPeliculasApi)
            };

            return View(listaPeliculasCategorias);
        }

        public async Task<IActionResult> IndexCategoria(int id)
        {
            var pelisEnCategoria = await _repoPelicula.GetPeliculasEnCategoriaAsync(CT.RutaPeliculasEnCategoriaApi, id);
            return View(pelisEnCategoria);
        }

        public async Task<IActionResult> IndexBusqueda(string nombre)
        {
            var pelisEncontradas = await _repoPelicula.Buscar(CT.RutaPeliculasApiBusqueda, nombre);
            return View(pelisEncontradas);
        }

        [HttpGet]
        public IActionResult Login()
        {
            UsuarioM usuario = new UsuarioM();
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsuarioM obj)
        {
            if (ModelState.IsValid)
            {
                UsuarioM objUser = await _repoAccount.LoginAsync(CT.RutaUsuariosApi + "Login", obj);
                if (objUser == null)
                {
                    TempData["alert"] = "Los datos son incorrectos";
                    return View();//vuelve al formulario
                }

                //crea token

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //guarda en el navegador el nombre del usuario
                identity.AddClaim(new Claim(ClaimTypes.Name, objUser.Usuario));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //creamos la sesion
                HttpContext.Session.SetString("JWToken", objUser.Token);
                TempData["alert"] = "Bienvenido/a " + objUser.Usuario;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(UsuarioM obj)
        {
            bool result = await _repoAccount.RegisterAsync(CT.RutaUsuariosApi + "Registro", obj);
            if (result == false)
            {
                return View();
            }
            TempData["alert"] = "Registro correctos";
            return RedirectToAction("Login");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
