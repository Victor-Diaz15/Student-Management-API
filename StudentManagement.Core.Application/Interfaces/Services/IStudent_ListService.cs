using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Interfaces.Services
{
    public interface IStudent_ListService : IGenericService<Student_Dto, Student_List>
    {
        Task<List<Student_Dto>> GetAllWithFilters(Student_Filters_Dto filters);
    }
}
