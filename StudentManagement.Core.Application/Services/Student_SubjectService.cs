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
    public class Student_SubjectService : GenericService<Student_Subject_Dto, Student_Subject>, IStudent_SubjectService
    {
        private readonly IStudent_SubjectRepository _repo;
        private readonly IStudentRepository _studentRepo;
        private readonly ISubjectRepository _subjectRepo;
        private readonly IMapper _mapper;
        public Student_SubjectService
            (IStudent_SubjectRepository repo, IStudentRepository studentRepo, ISubjectRepository subjectRepo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _studentRepo = studentRepo;
            _subjectRepo = subjectRepo;
            _mapper = mapper;
        }

        public async Task<List<StudentSubjectRes_Dto>> GetAllWithInclude()
        {
            List<StudentSubjectRes_Dto> res = new();
            var data = await _repo.GetAllAsync();

            foreach (var item in data)
            {
                StudentSubjectRes_Dto stRes = new();
                var student = await _studentRepo.GetByIdAsync(item.StudentId);
                var subject = await _subjectRepo.GetByIdAsync(item.SubjectId);
                stRes.Id = item.Id;
                stRes.StudentName = $"{student.FirstName} {student.LastName}";
                stRes.SubjectName = subject.Name;
                stRes.Grade = item.Grade;
                stRes.Literal = item.Literal;

                res.Add(stRes);
            }

            return res;
        }

        public override Task<Student_Subject_Dto> AddAsync(Student_Subject_Dto vm)
        {
            if (vm.Grade <= 69)
            {
                vm.Literal = Literals.F.ToString();
            }
            else if(vm.Grade <= 79)
            {
                vm.Literal = Literals.C.ToString();
            }
            else if (vm.Grade <= 89)
            {
                vm.Literal = Literals.B.ToString();
            }
            else if (vm.Grade <= 100)
            {
                vm.Literal = Literals.A.ToString();
            }

            return base.AddAsync(vm);
        }

        public override Task UpdateAsync(Student_Subject_Dto vm, int id)
        {
            if (vm.Grade <= 69)
            {
                vm.Literal = Literals.F.ToString();
            }
            else if (vm.Grade <= 79)
            {
                vm.Literal = Literals.C.ToString();
            }
            else if (vm.Grade <= 89)
            {
                vm.Literal = Literals.B.ToString();
            }
            else if (vm.Grade <= 100)
            {
                vm.Literal = Literals.A.ToString();
            }

            return base.UpdateAsync(vm, id);
        }
    }
}
