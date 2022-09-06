using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        Task<List<ViewModel>> GetAllAsync();
        Task<SaveViewModel> GetByIdAsync(int id);
        Task<SaveViewModel> AddAsync(SaveViewModel vm);
        Task UpdateAsync(SaveViewModel vm, int id);
        Task DeleteAsync(int id);
    }
}
