using AutoMapper;
using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Application.Enuns;
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
    public class Student_ListService : GenericService<Student_List_Dto, Student_List>, IStudent_ListService
    {
        private readonly IStudent_ListRepository _repo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        public Student_ListService
            (IStudent_ListRepository repo, IStudentRepository studentRepo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<List<StudentListRes_Dto>> GetAllWithInclude()
        {
            List<StudentListRes_Dto> res = new();
            var data = await _repo.GetAllAsync();

            foreach (var item in data)
            {
                
                StudentListRes_Dto stRes = new();
                stRes.Id = item.Id;
                stRes.StudentId = item.StudentId;
                stRes.StudentName = item.StudentName;
                stRes.Present = item.Present;
                stRes.Excuse = item.Excuse;
                stRes.Ausence = item.Ausence;
                stRes.Created = item.Created;

                var student = await _studentRepo.GetByIdAsync(item.StudentId);
                if (student != null)
                {
                    stRes.StudentExist = true;
                }
                else
                {
                    stRes.StudentExist = false;
                }

                res.Add(stRes);
            }

            return res;
        }

        public async override Task<Student_List_Dto> AddAsync(Student_List_Dto vm)
        {
            var student = await _studentRepo.GetByIdAsync(vm.StudentId);
            vm.StudentName = $"{student.FirstName} {student.LastName}";
            return await base.AddAsync(vm);
        }
    }
}
