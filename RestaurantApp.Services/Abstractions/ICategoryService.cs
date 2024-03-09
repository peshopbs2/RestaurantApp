using RestaurantApp.Data.Entities;
using RestaurantApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<List<CategoryDTO>> GetCategoryByNameAsync(string name);
        Task AddCategoryAsync(CategoryDTO category);
        Task DeleteCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(CategoryDTO category);
    }
}
