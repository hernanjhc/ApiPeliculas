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
    public class PeliculasController : Controller
    {
        private readonly IPeliculaRepository _ctPeli;
        private readonly IMapper _mapper;

        public PeliculasController(IPeliculaRepository ctPeli, IMapper mapper)
        {
            _ctPeli = ctPeli;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPeliculas()
        {
            var listaPeliculas = _ctPeli.GetPeliculas();
            var listaPeliculasDto = new List<PeliculaDTO>();
            foreach (var item in listaPeliculas)
            {
                listaPeliculasDto.Add(_mapper.Map<PeliculaDTO>(item));
            }
            return Ok(listaPeliculasDto);
        }

        [Route ("GetPelicula")]
        [HttpGet]
        //[HttpGet("{PeliculaId:int}", Name = "GetPelicula")]
        public IActionResult GetPelicula(int PeliculaId)
        {
            var itemPelicula = _ctPeli.GetPelicula(PeliculaId);
            if (itemPelicula == null)
            {
                return NotFound();
            }
            var itemPeliculaDto = _mapper.Map<PeliculaDTO>(itemPelicula);

            return Ok(itemPeliculaDto);
        }

        [Route("CrearPelicula")]
        //FromBody obtiene lo que llega en el body del envio.
        [HttpPost]
        public IActionResult CrearPelicula([FromBody] PeliculaDTO PeliculaDTO)
        {
            if (PeliculaDTO==null)
            {
                return BadRequest(ModelState);
            }
            if (_ctPeli.ExistePelicula(PeliculaDTO.Nombre))
            {
                ModelState.AddModelError("", "La Pelicula ya existe...");
                return StatusCode(404, ModelState);
            }

            var Pelicula = _mapper.Map<Pelicula>(PeliculaDTO);
            if (!_ctPeli.CrearPelicula(Pelicula))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {Pelicula.Nombre}");
                return StatusCode(500, ModelState);
            }
            //http code 201, y devuelve último registro creado.
            return CreatedAtRoute("GetPelicula", new { PeliculaId = Pelicula.Id}, Pelicula);
        }

        [HttpPatch("{PeliculaId:int}", Name = "ActualizarPelicula")]
        public IActionResult ActualizarPelicula(int PeliculaId, [FromBody] PeliculaDTO PeliculaDTO)
        {
            if (PeliculaDTO == null || PeliculaId != PeliculaDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var Pelicula = _mapper.Map<Pelicula>(PeliculaDTO);
            if (!_ctPeli.ActualizarPelicula(Pelicula))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro {Pelicula.Nombre}");
                return StatusCode(500, ModelState);
            }

            //http ode 204. Server job ok
            return NoContent();
        }

        [HttpDelete("{PeliculaId:int}", Name = "BorrarPelicula")]
        public IActionResult BorrarPelicula(int PeliculaId)
        {
            if (!_ctPeli.ExistePelicula(PeliculaId))
            {
                return NotFound();
            }

            var Pelicula = _ctPeli.GetPelicula(PeliculaId);
            if (!_ctPeli.BorrarPelicula(Pelicula))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {Pelicula.Nombre}");
                return StatusCode(500, ModelState);
            }

            //http ode 204. Server job ok
            return NoContent();
        }
    }
}
