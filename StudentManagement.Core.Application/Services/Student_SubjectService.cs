using AutoMapper;
using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Core.Application.Interfaces.Services;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Services
{
    public class Student_SubjectService : GenericService<Student_Subject_Dto, Student_Subject>, IStudent_SubjectService
    {
        private readonly IStudent_SubjectRepository _repo;
        private readonly IMapper _mapper;
        public Student_SubjectService(IStudent_SubjectRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
