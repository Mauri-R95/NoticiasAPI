using Noticias.API.ViewModel;
using Noticias.Domain.Models.Noticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.API.Mapper
{
    public static class NoticiaMapper
    {
        public static Noticia Map(NoticiaModel model) {
            return new Noticia(
                model.Id, 
                model.Titulo, 
                model.Descripcion, 
                model.Contenido, 
                model.AutorID,
                DateTime.Now
            );
        }

        public static NoticiaModel MapEtM(Noticia noticia) {
            return new NoticiaModel()
            {
                Id = noticia.NoticiaID,
                Titulo = noticia.Titulo,
                Descripcion = noticia.Descripcion,
                Contenido = noticia.Contenido,
                AutorID = noticia.AutorID

            };

        }

        public static IEnumerable<NoticiaModel> Maps(IEnumerable<Noticia> noticias)
        {
            List<NoticiaModel> nm = new List<NoticiaModel>();
            nm = noticias.Select(x => new NoticiaModel()
            {
                AutorID = x.AutorID,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                Contenido = x.Contenido,
                Id = x.NoticiaID

            }).ToList();
            return nm;
        }
        
    }
}
