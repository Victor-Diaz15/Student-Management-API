using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Interfaces.Services
{
    public interface IStudent_ListService : IGenericService<Student_List_Dto, Student_List>
    {
        Task<List<StudentListRes_Dto>> GetAllWithInclude();
    }
}
