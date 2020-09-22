using Noticias.API.ViewModel;
using Noticias.Domain.Models.Noticia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.API
{
    public interface INoticiaService
    {
        Task<IEnumerable<NoticiaModel>> GetNoticias();
        Task<Noticia> GetNoticia(int id);
        Task<Noticia> AgregarNoticia(Noticia _noticia);
        Task<Noticia> EditarNoticia(Noticia _noticia);
        Task<bool> EliminarNoticia(int Id);
    }
}
