using ApiPeliculas.Models;
using ApiPeliculas.Models.DTOs;
using ApiPeliculas.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculas.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiPeliculasUsuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UsuariosController(IUsuarioRepository userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        //[AllowAnonymous]  Se quita permitir acceso a metodo sin autenticacion.
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _userRepo.GetUsuarios();
            var listaUsuariosDTO = new List<UsuarioDTO>();

            foreach (var item in listaUsuarios)
            {
                listaUsuariosDTO.Add(_mapper.Map<UsuarioDTO>(item));
            }
            return Ok(listaUsuariosDTO);
        }

        //[AllowAnonymous]  Se quita permitir acceso a metodo sin autenticacion.
        [HttpGet]
        [Route("GetUsuario")]
        public IActionResult GetUsuario(int usuarioId)
        {
            var usuario = _userRepo.GetUsuario(usuarioId);
            if (usuario==null)
            {
                return NotFound();
            }

            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return Ok(usuarioDTO);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registro")]
        public IActionResult Registro(UsuarioAuthDTO usuarioAuthDTO)
        {
            usuarioAuthDTO.UsuarioA = usuarioAuthDTO.UsuarioA.ToLower();
            if (_userRepo.ExisteUsuario(usuarioAuthDTO.UsuarioA))
            {
                return BadRequest("El usuario ya existe.");
            }

            var usuarioACrear = new Usuario
            {
                UsuarioA = usuarioAuthDTO.UsuarioA
            };

            var usuarioCreado = _userRepo.Registro(usuarioACrear, usuarioAuthDTO.Password);
            return Ok(usuarioCreado);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UsuarioAuthLoginDTO usuarioAuthLoginDTO)
        {
            var usuarioDesdeRepo = _userRepo.Login(usuarioAuthLoginDTO.Usuario, usuarioAuthLoginDTO.Password);

            if (usuarioDesdeRepo == null)
            {
                return Unauthorized();
            }

            //Construyendo PayLoad
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioDesdeRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, usuarioDesdeRepo.UsuarioA.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };

            //Generación de Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new 
            {
                usuario = claims[1].Value.ToString(),
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
