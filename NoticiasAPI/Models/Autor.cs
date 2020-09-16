﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Models
{
    public class Autor
    {
        public int AutorID {get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Autor> mapeoAutor)
            {
                mapeoAutor.HasKey(x => x.AutorID);
                mapeoAutor.Property(x => x.Nombre);
                mapeoAutor.Property(x => x.Apellido);
                //mapeoAutor.ToTable("Autor_au"); ejemplo para el nombre de la tabla
                mapeoAutor.ToTable("Autor");


            }
        }
    }

   
}