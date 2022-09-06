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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly AppDbContext _db;
        public SubjectRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
