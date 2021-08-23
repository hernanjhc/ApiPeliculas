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
    [ApiExplorerSettings(GroupName = "ApiPeliculasCategorias")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _ctRepo = categoriaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtener todas las categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type =typeof(List<CategoriaDTO>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategorias()
        {
            var listaCategorias = _ctRepo.GetCategorias();
            var listaCategoriasDto = new List<CategoriaDTO>();
            foreach (var item in listaCategorias)
            {
                listaCategoriasDto.Add(_mapper.Map<CategoriaDTO>(item));
            }
            return Ok(listaCategoriasDto);
        }

        /// <summary>
        /// Obtener una categoria individual
        /// </summary>
        /// <param name="categoriaId">Este es el id de la categoria</param>
        /// <returns></returns>
        [Route ("GetCategoria")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CategoriaDTO))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        //[HttpGet("{categoriaId:int}", Name = "GetCategoria")]
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _ctRepo.GetCategoria(categoriaId);
            if (itemCategoria == null)
            {
                return NotFound();
            }
            var itemCategoriaDto = _mapper.Map<CategoriaDTO>(itemCategoria);

            return Ok(itemCategoriaDto);
        }

        /// <summary>
        /// Crear una nueva categoria
        /// </summary>
        /// <param name="categoriaDTO"></param>
        /// <returns></returns>
        [Route("CrearCategoria")]
        //FromBody obtiene lo que llega en el body del envio.
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoriaDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult CrearCategoria([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO==null)
            {
                return BadRequest(ModelState);
            }
            if (_ctRepo.ExisteCategoria(categoriaDTO.Nombre))
            {
                ModelState.AddModelError("", "La categoria ya existe...");
                return StatusCode(404, ModelState);
            }

            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            if (!_ctRepo.CrearCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            //http code 201, y devuelve último registro creado.
            return CreatedAtRoute("GetCategoria", new { categoriaId = categoria.Id}, categoria);
        }

        /// <summary>
        /// Actualizar una categoria.
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <param name="categoriaDTO"></param>
        /// <returns></returns>
        [HttpPatch("{categoriaId:int}", Name = "ActualizarCategoria")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarCategoria(int categoriaId, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null || categoriaId != categoriaDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            if (!_ctRepo.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }

            //http ode 204. Server job ok
            return NoContent();
        }

        /// <summary>
        /// Borrar una categoria.
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <returns></returns>
        [HttpDelete("{categoriaId:int}", Name = "BorrarCategoria")]
        [ProducesResponseType(201, Type = typeof(CategoriaDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult BorrarCategoria(int categoriaId)
        {
            if (!_ctRepo.ExisteCategoria(categoriaId))
            {
                return NotFound();
            }

            var categoria = _ctRepo.GetCategoria(categoriaId);
            if (!_ctRepo.BorrarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }

            //http ode 204. Server job ok
            return NoContent();
        }
    }
}
