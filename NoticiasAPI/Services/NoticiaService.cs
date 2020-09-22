using Microsoft.EntityFrameworkCore;
using Noticias.API;
using Noticias.API.Mapper;
using Noticias.API.ViewModel;
using Noticias.Domain.Models;
using Noticias.Domain.Models.Noticia;
using Noticias.Infrastructure;
using Noticias.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly SqlConfiguration _sqlConfiguration;
        private INoticiaRepository _noticiaRepository;
        public NoticiaService(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
            _noticiaRepository = new NoticiaRepository(sqlConfiguration);
        }

        public Task<Noticia> GetNoticia(int id)
        {
            return _noticiaRepository.Get(id);
        }

        public async Task<IEnumerable<NoticiaModel>> GetNoticias()
        {
            IEnumerable<Noticia> result = await _noticiaRepository.GetAll();
            IEnumerable<NoticiaModel> noticias = NoticiaMapper.Maps(result);
            return noticias;
        }

        public async Task<Noticia> AgregarNoticia(Noticia _noticia)
        {
            try
            {
                if (_noticia.Id == 0) 
                //if (_noticia.NoticiaID == 0) 
                    return await _noticiaRepository.Adds(_noticia);
                //await _noticiasDBContext.SaveChangesAsync();
                else
                    return null;
            }
            catch (Exception error)
            {
                return null;
            }

        }

        public async Task<Noticia> EditarNoticia(Noticia _noticia)
        {
            try
            {
                return await _noticiaRepository.Update(_noticia.NoticiaID, _noticia);
                //var noticiaBD = _noticiasDBContext.Noticia.Where(b => b.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                //noticiaBD.Titulo = _noticia.Titulo;
                //noticiaBD.Descripcion = _noticia.Descripcion;
                //noticiaBD.Contenido = _noticia.Contenido;
                //noticiaBD.Fecha = _noticia.Fecha;
                //noticiaBD.AutorID= _noticia.AutorID;
                ////_noticiasDBContext.SaveChanges();
                //return true;
            }
            catch
            {
                return null;
            }
        }

        public Task<bool> EliminarNoticia(int Id)
        {
            try
            {
                return _noticiaRepository.DeleteAsync(Id);
               // var noticiaBD = _noticiasDBContext.Noticia.Where(b => b.NoticiaID == NoticiaID).FirstOrDefault();
               // _noticiasDBContext.Noticia.Remove(noticiaBD);
               //// _noticiasDBContext.SaveChanges();
                //return true;
            }
            catch(Exception error)
            {
                return null;
            }
        }
    }
}
