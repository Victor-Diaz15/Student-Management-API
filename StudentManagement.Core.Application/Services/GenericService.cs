using AutoMapper;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<ViewModel>> GetAllAsync()
        {
            var entityList = await _genericRepository.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(entityList);
        }
        public virtual async Task<SaveViewModel> GetByIdAsync(int id)
        {
            Entity entity = await _genericRepository.GetByIdAsync(id);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
            return vm;
        }
        public virtual async Task<SaveViewModel> AddAsync(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _genericRepository.AddAsync(entity);
            SaveViewModel viewModel = _mapper.Map<SaveViewModel>(entity);
            return viewModel;
        }
        public virtual async Task UpdateAsync(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _genericRepository.UpdateAsync(entity, id);
        }
        public virtual async Task DeleteAsync(int id)
        {
            Entity entity = await _genericRepository.GetByIdAsync(id);
            await _genericRepository.DeleteAsync(entity);
        }
    }
}
