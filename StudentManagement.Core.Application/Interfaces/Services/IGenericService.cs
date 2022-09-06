using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Interfaces.Services
{
    public interface IGenericService<Dto, Entity>
        where Dto : class
        where Entity : class
    {
        Task<List<Dto>> GetAllAsync();
        Task<Dto> GetByIdAsync(int id);
        Task<Dto> AddAsync(Dto vm);
        Task UpdateAsync(Dto vm, int id);
        Task DeleteAsync(int id);
    }
}
