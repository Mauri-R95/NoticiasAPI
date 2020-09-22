using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noticias.Domain.Models.Autor;
using Noticias.Domain.Models.Noticia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noticias.Infrastructure.EntityConfig
{
    public class NoticiaEntityConfig : IEntityTypeConfiguration<Noticia>
    {

        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.HasKey(x => x.NoticiaID);
            builder.Property(x => x.Titulo).HasColumnName("Titulo");
            builder.Property(x => x.Descripcion);
            //(mapeoNoticia.ToTable("Noticia_noti");
            builder.ToTable("Noticia");
            builder.HasOne<Autor>().WithMany().IsRequired(true).HasForeignKey("AutorID");
        }
    }
}
