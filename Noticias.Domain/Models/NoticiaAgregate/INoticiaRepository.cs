using MicroService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Noticias.Domain.Models.Noticia
{
    public interface INoticiaRepository : IRepository<Noticia>
    {
        IEnumerable<Noticia> GetAlls();
        Task<Noticia> Adds(Noticia e);
    }
}
