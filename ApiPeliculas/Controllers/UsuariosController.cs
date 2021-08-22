using ApiPeliculas.Models;
using ApiPeliculas.Models.DTOs;
using ApiPeliculas.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _userRepo;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

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
    }
}
