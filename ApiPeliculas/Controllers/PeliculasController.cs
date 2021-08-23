using ApiPeliculas.Models;
using ApiPeliculas.Models.DTOs;
using ApiPeliculas.Repositories.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiPeliculas")]
    public class PeliculasController : Controller
    {
        private readonly IPeliculaRepository _ctPeli;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PeliculasController(IPeliculaRepository ctPeli, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _ctPeli = ctPeli;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }


        [AllowAnonymous]
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

        [Route("GetPelicula")]
        [AllowAnonymous]
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

        [Route("BuscarPelicula")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Buscar(string nombre)
        {
            try
            {
                var resultado = _ctPeli.BuscarPelicula(nombre);
                if (resultado.Any())
                {
                    return Ok(resultado);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos de la aplicación.");
            }
        }


        [Route("CrearPelicula")]
        //FromBody obtiene lo que llega en el body del envio.
        [HttpPost]
        public IActionResult CrearPelicula([FromForm] PeliculaCreateDTO peliculaCreateDTO)
        {
            if (peliculaCreateDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (_ctPeli.ExistePelicula(peliculaCreateDTO.Nombre))
            {
                ModelState.AddModelError("", "La Pelicula ya existe...");
                return StatusCode(404, ModelState);
            }

            //Subida de archivos
            var archivo = peliculaCreateDTO.Foto;
            string rutaPrincipal = _hostingEnvironment.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;
            if (archivo.Length > 0)
            {
                //Nueva imagen
                var nombreFoto = Guid.NewGuid().ToString();
                var subidas = Path.Combine(rutaPrincipal, @"fotos");
                var extension = Path.GetExtension(archivos[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(subidas, nombreFoto + extension), FileMode.Create))
                {
                    archivos[0].CopyTo(fileStream);
                }
                peliculaCreateDTO.RutaImagen = @"\fotos\" + nombreFoto + extension;
            }

            //mapeo de peliculas
            var Pelicula = _mapper.Map<Pelicula>(peliculaCreateDTO);
            if (!_ctPeli.CrearPelicula(Pelicula))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {Pelicula.Nombre}");
                return StatusCode(500, ModelState);
            }

            //http code 201, y devuelve último registro creado.
            return CreatedAtRoute("CrearPelicula", new { PeliculaId = Pelicula.Id }, Pelicula);
        }


        [AllowAnonymous]
        [HttpGet("GetPeliculasEnCategoria/{categoriaId:int}")]
        public IActionResult GetPeliculasEnCategoria(int categoriaId)
        {
            var listaPeliculas = _ctPeli.GetPeliculasEnCategoria(categoriaId);
            if (listaPeliculas == null)
            {
                return NotFound();
            }

            var itemPelicula = new List<PeliculaDTO>();
            foreach (var item in listaPeliculas)
            {
                itemPelicula.Add(_mapper.Map<PeliculaDTO>(item));
            }
            return Ok(itemPelicula);
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
