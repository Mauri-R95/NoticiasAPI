using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Models;
using Noticias.Domain.Models.Autor;
using Noticias.Domain.Models.Noticia;
using Noticias.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.Infrastructure
{
    public class NoticiasDBContext : DbContext, INoticiasDBContext
    {

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public NoticiasDBContext(DbContextOptions options) : base(options)
        {

        }
        public NoticiasDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorEntityConfig());
            modelBuilder.ApplyConfiguration(new NoticiaEntityConfig());

            //autorEntityConfig.Configure(modelBuilder.Entity<Noticia>());
            //AutorEntityConfig.setEntityBuilder(modelBuilder.Entity<Autor>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
