using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection svc)
        {
            svc.AddSwaggerGen(opt =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => opt.IncludeXmlComments(xmlFile));

                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "StudentManagement API",
                    Description = "This API will be resposible for overall data distribution",
                    Contact = new OpenApiContact
                    {
                        Name = "Victor Diaz",
                        Email = "victordiaz123julioarias@gmail.com"
                    }
                });
                opt.DescribeAllParametersInCamelCase();
            });
        }
    }
}
