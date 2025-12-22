using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Category;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryCreateDto model)
        {
            var category = _mapper.Map<Category>(model);
            await _repository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var deleteCategory = await _repository.GetByIdAsync(id);
            if (deleteCategory == null) throw new NotFoundException("Category notfound");
            var category = _mapper.Map<Category>(deleteCategory);
            await _repository.DeleteAsync(category);
        }

        public async Task EditAsync(int id, CategoryEditDto model)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException("Category notfound");
            category.Name = model.Name;
            category.IsActive = model.IsActive;
            await _repository.EditAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
           var categories =  await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException("Category notfound");
            return _mapper.Map<CategoryDto>(category);
        }
    }
}