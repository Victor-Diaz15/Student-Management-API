using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Core.Domain.Entities;
using StudentManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Persistence.Repositories
{
    public class Student_SubjectRepository : GenericRepository<Student_Subject>, IStudent_SubjectRepository
    {
        private readonly AppDbContext _db;
        public Student_SubjectRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
