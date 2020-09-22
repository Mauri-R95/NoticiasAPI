using MicroService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using not = Noticias.Domain.Models.Noticia;

namespace Noticias.Domain.Models.Autor
{
    public class Autor : Entity, IAggregateRoot
    {
        public int AutorID {get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }

       public virtual ICollection<not.Noticia> Noticias { get;set; } 


    }

   
}
