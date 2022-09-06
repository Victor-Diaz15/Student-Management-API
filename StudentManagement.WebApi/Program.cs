using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Infrastructure.Persistence.Repositories;
using StudentManagement.Infrastructure.Persistence.Seeds.subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Creating the dependency injection manually
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var subjectRepo = services.GetRequiredService<ISubjectRepository>();

                    await DefaultLengua_Española.SeedAsync(subjectRepo);
                    await DefaultMatematica.SeedAsync(subjectRepo);
                    await DefaultCiencias_Sociales.SeedAsync(subjectRepo);
                    await DefaultCiencias_Naturales.SeedAsync(subjectRepo);

                }
                catch (Exception)
                {

                    throw;
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
