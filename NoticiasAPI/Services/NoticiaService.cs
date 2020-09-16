using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaService
    {
        private readonly NoticiasDBContext _noticiasDBContext;
        public NoticiaService(NoticiasDBContext noticiasDBContext)
        {
            _noticiasDBContext = noticiasDBContext;
        }

        public List<Noticia> GetNoticias()
        {
            var result = _noticiasDBContext.Noticia.Include(x => x.Autor).ToList();
            return result;
        }

        public Boolean AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiasDBContext.Noticia.Add(_noticia);
                _noticiasDBContext.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }

        }

        public Boolean EditarNoticia(Noticia _noticia)
        {
            try
            {
                var noticiaBD = _noticiasDBContext.Noticia.Where(b => b.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBD.Titulo = _noticia.Titulo;
                noticiaBD.Descripcion = _noticia.Descripcion;
                noticiaBD.Contenido = _noticia.Contenido;
                noticiaBD.Fecha = _noticia.Fecha;
                noticiaBD.AutorID= _noticia.AutorID;
                _noticiasDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean EliminarNoticia(int NoticiaID)
        {
            try
            {
                var noticiaBD = _noticiasDBContext.Noticia.Where(b => b.NoticiaID == NoticiaID).FirstOrDefault();
                _noticiasDBContext.Noticia.Remove(noticiaBD);
                _noticiasDBContext.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }
    }
}
