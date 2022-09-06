using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Infrastructure.Persistence.Contexts;
using StudentManagement.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Persistence
{
    //Main reason for creating this class is to follow the Single responsability
    public static class ServiceRegistration
    {
        // Extension methods | "Decorator"
        // This allows us to extend and create new functionallity following "Open-Closed Principle"
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                service.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            }

            #region 'repositories'

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient<ISubjectRepository, SubjectRepository>();
            service.AddTransient<IStudent_SubjectRepository, Student_SubjectRepository>();

            #endregion
        }
    }
}
