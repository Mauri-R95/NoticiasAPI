using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Models;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }
        [HttpGet]
        [Route("obtener")]
        public IActionResult GetNoticias()
        {
            var result = _noticiaService.GetNoticias();
            return Ok(result);
        }

        [HttpPost] //api/noticia/agregar
        [Route("agregar")]
        public IActionResult AddNoticia([FromBody] Noticia _noticia)
        {
            var result = _noticiaService.AgregarNoticia(_noticia);
            if (result)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPut] //api/noticia/editar
        [Route("editar")]
        public IActionResult EditarNoticia([FromBody] Noticia _noticia)
        {
            var result = _noticiaService.EditarNoticia(_noticia);
            if (result)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpDelete] //api/noticia/editar
        [Route("eliminar/{NoticiaID}")]
        public IActionResult EliminarNoticia(int NoticiaID)
        {
            var result = _noticiaService.EliminarNoticia(NoticiaID);
            if (result)
                return Ok(result);
            else
                return BadRequest();
        }


    }
}
