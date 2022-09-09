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
    public class SubjectService : GenericService<Subject_Dto, Subject>, ISubjectService
    {
        private readonly ISubjectRepository _repo;
        private readonly IStudent_SubjectRepository _student_SubjectRepo;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository repo, IStudent_SubjectRepository student_SubjectRepo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _student_SubjectRepo = student_SubjectRepo;
            _mapper = mapper;
        }

        public async override Task DeleteAsync(int id)
        {
            // Eliminando las studentSubjects que tienen relacion con las materias.
            List<Student_Subject> stSList = await _student_SubjectRepo.GetAllAsync();
            foreach (Student_Subject item in stSList)
            {
                if (item.SubjectId == id)
                {
                    await _student_SubjectRepo.DeleteAsync(item);
                }
            }
            await base.DeleteAsync(id);
        }
    }
}
