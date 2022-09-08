using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Core.Application.Interfaces.Services;
using StudentManagement.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application
{
    //Extension Methods - application of this design pattern Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services

            service.AddTransient<IStudentService, StudentService>();
            service.AddTransient<ISubjectService, SubjectService>();
            service.AddTransient<IStudent_SubjectService, Student_SubjectService>();
            service.AddTransient<IStudent_ListService, Student_ListService>();

            #endregion
        }
    }
}
