using StudentManagement.Core.Application.Enuns;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Persistence.Seeds.subjects
{
    public static class DefaultLengua_Española
    {
        public static async Task SeedAsync(ISubjectRepository _repo)
        {
            Subject subject = new();
            subject.Name = Subjects.Lengua_Española.ToString();

            var subjects = await _repo.GetAllAsync();

            if (subjects.All(e => e.Name.ToLower() != subject.Name.ToLower()))
            {
                var newSubject = await _repo.AddAsync(subject);
            }
        }
    }
}
