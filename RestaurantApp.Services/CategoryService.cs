using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories.Abstractions;
using RestaurantApp.Services.Abstractions;

namespace RestaurantApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICrudRepository<Category> _repository;
        //TODO: add automapper
        public CategoryService(ICrudRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _repository.AddAsync(category);
        }

        public async Task DeleteCategoryByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return (await _repository.GetAllAsync())
                .ToList();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoryByNameAsync(string name)
        {
            return (await _repository.GetAsync(item => item.Name == name))
                .ToList();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _repository.UpdateAsync(category);
        }
    }
}