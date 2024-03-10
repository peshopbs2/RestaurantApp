using RestaurantApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDTO>> GetRestaurantsAsync();
        Task<RestaurantDTO> GetRestaurantByIdAsync(int id);
        Task<List<RestaurantDTO>> GetRestaurantByNameAsync(string name);
        Task AddRestaurantAsync(RestaurantDTO model);
        Task DeleteRestaurantByIdAsync(int id);
        Task UpdateRestaurantAsync(RestaurantDTO model);
    }
}
