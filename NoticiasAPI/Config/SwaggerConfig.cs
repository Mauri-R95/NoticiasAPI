using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Noticias.API.Config
{
    public static class SwaggerConfig
    {
        //Descripcion y documentacion de apps, para testiarlas y programarlas rapidamente
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {

            var basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basepath, "NoticiasAPIv1.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Noticias API 1",
                    Version = "1.0"
                });
                //c.IncludeXmlComments(xmlPath);

            }
            );
            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Noticias API 1");
                c.RoutePrefix = String.Empty;

            });
            return app;

        }
    }
}
