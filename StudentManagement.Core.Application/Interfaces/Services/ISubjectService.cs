using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Interfaces.Services
{
    public interface ISubjectService : IGenericService<Subject_Dto, Subject>
    {
    }
}
