using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeliculasWeb.Models;
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

        public HomeController(ILogger<HomeController> logger, IAccountRepository repoAccount)
        {
            _logger = logger;
            _repoAccount = repoAccount;
        }

        public IActionResult Index()
        {
            return View();
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
                if (objUser.Token == null)
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
