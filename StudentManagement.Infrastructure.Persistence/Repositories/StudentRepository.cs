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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AppDbContext _db;
        public StudentRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
