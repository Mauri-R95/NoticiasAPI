using Microsoft.Extensions.DependencyInjection;
using Noticias.Domain.Models.Autor;
using Noticias.Domain.Models.Noticia;
using NoticiasAPI.Services;
using Noticias.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Noticias.API
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
           // AddRegisterOthers(services);

            return services;
        }

        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<INoticiaService, NoticiaService>();
            //services.AddScoped<INoticiaService, NoticiaService>();
            return services;
        }
        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            //La implementacion del servicio es en base a la interfaz
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<INoticiaRepository, NoticiaRepository>();
            return services;
        }

    }    
}
