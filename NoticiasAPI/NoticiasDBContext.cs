using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI
{
    public class NoticiasDBContext : DbContext
    {
        public NoticiasDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Noticia.Mapeo(modelBuilder.Entity<Noticia>());
            new Autor.Mapeo(modelBuilder.Entity<Autor>());
        }
    }
}
