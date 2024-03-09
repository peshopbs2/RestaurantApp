using AutoMapper;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories.Abstractions;
using RestaurantApp.Services.Abstractions;
using RestaurantApp.Services.DTOs;

namespace RestaurantApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICrudRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICrudRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddCategoryAsync(CategoryDTO model)
        {
            var category = _mapper
                .Map<Category>(model);

            await _repository.AddAsync(category);
        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = (await _repository.GetAllAsync())
                .ToList();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<List<CategoryDTO>> GetCategoryByNameAsync(string name)
        {
            var categories = (await _repository.GetAsync(item => item.Name == name))
                .ToList();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task UpdateCategoryAsync(CategoryDTO model)
        {
            var category = _mapper.Map<Category>(model);
            await _repository.UpdateAsync(category);
        }
    }
}