using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models;

namespace Offense_Detector.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Offense Detector",
                    Description = "The Offense Detector is a simple API for identifying offensive language in texts.",
                    Version = "v1"
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath =  Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}