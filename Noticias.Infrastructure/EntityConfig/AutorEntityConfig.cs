using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noticias.Domain.Models;
using Noticias.Domain.Models.Autor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noticias.Infrastructure.EntityConfig
{
    public class AutorEntityConfig : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(x => x.AutorID);
            builder.Property(x => x.Nombre);
            builder.Property(x => x.Apellido);
            //mapeoAutor.ToTable("Autor_au"); ejemplo para el nombre de la tabla
            builder.ToTable("Autor");
        }
    }
}
