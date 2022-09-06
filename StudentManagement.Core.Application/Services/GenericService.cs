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
    public class GenericService<Dto, Entity> : IGenericService<Dto, Entity>
        where Dto : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<Dto>> GetAllAsync()
        {
            var entityList = await _genericRepository.GetAllAsync();
            return _mapper.Map<List<Dto>>(entityList);
        }
        public virtual async Task<Dto> GetByIdAsync(int id)
        {
            Entity entity = await _genericRepository.GetByIdAsync(id);
            Dto vm = _mapper.Map<Dto>(entity);
            return vm;
        }
        public virtual async Task<Dto> AddAsync(Dto vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _genericRepository.AddAsync(entity);
            Dto viewModel = _mapper.Map<Dto>(entity);
            return viewModel;
        }
        public virtual async Task UpdateAsync(Dto vm, int id)
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
