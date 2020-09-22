using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noticias.API;
using Noticias.API.Mapper;
using Noticias.API.ViewModel;
using Noticias.Domain.Models;
using Noticias.Domain.Models.Noticia;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _noticiaService;
        public NoticiaController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(NoticiaModel))]
        public async Task<IActionResult> GetNoticia(int id)
        {
            NoticiaModel noticia = new NoticiaModel();
            var result = await _noticiaService.GetNoticia(id);
            if (result != null)
                return Ok(NoticiaMapper.MapEtM(result));
            else
                return NoContent();


        }

        [HttpGet]
        public IActionResult GetNoticias()
        {
            var result = _noticiaService.GetNoticias();
            if (result.Result.Count() > 0)
                return Ok(result.Result);
            else
                return BadRequest();

        }

        [HttpPost] //api/noticia/agregar
        public IActionResult AddNoticia([FromBody] NoticiaModel _noticia)
        {
            var result = _noticiaService.AgregarNoticia(NoticiaMapper.Map(_noticia));
            _noticia.Id = result.Result.NoticiaID;
            if (result != null)
                return Ok(_noticia);
            else
                return BadRequest();
        }

        [HttpPut] //api/noticia/
        public IActionResult EditarNoticia([FromBody] NoticiaModel _noticia)
        {
            var result = _noticiaService.EditarNoticia(NoticiaMapper.Map(_noticia));
            if (result.Result != null)
                return Ok(_noticia);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarNoticia(int Id)
        {
            var result = _noticiaService.EliminarNoticia(Id);
            if (result.Result)
                return Ok(result.Result);
            else
                return BadRequest();
        }


    }
}
