using RestaurantApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Abstractions
{
    public interface ICategoryService
    {
        //TODO: change entity to DTOs
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetCategoryByNameAsync(string name);
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(Category category);
    }
}
