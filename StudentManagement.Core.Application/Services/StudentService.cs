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
    public class StudentService : GenericService<Student_Dto, Student>, IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IStudent_SubjectRepository _student_SubjectRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repo, IStudent_SubjectRepository student_SubjectRepo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _student_SubjectRepo = student_SubjectRepo;
            _mapper = mapper;
        }

        public async Task<List<Student_Dto>> GetAllWithFilters(Student_Filters_Dto filters)
        {
            List<Student> students = await _repo.GetAllAsync();

            List<Student_Dto> listStudents = _mapper.Map<List<Student_Dto>>(students);

            if (!string.IsNullOrWhiteSpace(filters.FirstName))
            {
                listStudents = listStudents.Where(st => st.FirstName.Trim().ToLower() == filters.FirstName.Trim().ToLower()).ToList();
                return listStudents;
            }

            if (!string.IsNullOrWhiteSpace(filters.LastName))
            {
                listStudents = listStudents.Where(st => st.LastName.Trim().ToLower() == filters.LastName.Trim().ToLower()).ToList();
                return listStudents;
            }

            return listStudents;
        }

        public async override Task DeleteAsync(int id)
        {
            // Eliminando las studentSubjects del studiante.
            List<Student_Subject> stSList = await _student_SubjectRepo.GetAllAsync();
            foreach (Student_Subject item in stSList)
            {
                if (item.StudentId == id)
                {
                    await _student_SubjectRepo.DeleteAsync(item);
                }
            }
            await base.DeleteAsync(id);
        }
    }
}
