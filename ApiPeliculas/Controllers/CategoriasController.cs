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
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _ctRepo = categoriaRepository;
            _mapper = mapper;
        }
        [HttpGet]
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

        [Route ("GetCategoria")]
        [HttpGet]
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
    }
}
