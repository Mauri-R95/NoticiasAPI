using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.API.ViewModel
{
    public class NoticiaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public int AutorID { get; set; }

    }
}
