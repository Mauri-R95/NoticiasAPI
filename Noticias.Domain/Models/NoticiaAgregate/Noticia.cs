using MicroService.Domain.SeedWork;
using System;
using Noticias.Domain.Models.Autor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using au = Noticias.Domain.Models.Autor;
using System.Globalization;

namespace Noticias.Domain.Models.Noticia
{
    public class Noticia : Entity, IAggregateRoot
    {
        public int NoticiaID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int AutorID { get; set; }

        //public virtual au.Autor Autor{ get; set; }

        public Noticia(int noticiaId, string titulo, string descripcion, string contenido, int autorID, DateTime fecha)
        {
            Id = noticiaId;
            NoticiaID = noticiaId;
            Titulo = titulo;
            Descripcion = descripcion;
            Contenido = contenido;
            AutorID = autorID;
            Fecha = fecha;
        }

        public Noticia()
        {
                
        }

    }
}
