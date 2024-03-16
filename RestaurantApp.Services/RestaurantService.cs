using AutoMapper;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories.Abstractions;
using RestaurantApp.Services.Abstractions;
using RestaurantApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICrudRepository<Category>
            _categoryRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository,
            ICrudRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddRestaurantAsync(RestaurantCreateEditDTO model)
        {
            var restaurant = _mapper.Map<Restaurant>(model);

            var categories = model.CategoriesIds
                .Select(item => _categoryRepository.GetByIdAsync(item).Result)
                .ToList();
            restaurant.Categories = categories;
            await _restaurantRepository.AddAsync(restaurant);
        }

        public async Task DeleteRestaurantByIdAsync(int id)
        {
            await _restaurantRepository.DeleteByIdAsync(id);
        }

        public async Task<RestaurantDTO> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantRepository
                .GetByIdAsync(id);
            
            return _mapper.Map<RestaurantDTO>(restaurant);
        }

        public async Task<RestaurantCreateEditDTO> GetRestaurantByIdEditAsync(int id)
        {
            var restaurant = await _restaurantRepository
                .GetByIdAsync(id);
            return _mapper.Map<RestaurantCreateEditDTO>(restaurant);
        }
        public async Task<List<RestaurantDTO>> GetRestaurantByNameAsync(string name)
        {
            var restaurants = await _restaurantRepository.GetAsync(item => item.Name == name);
            return _mapper.Map<List<RestaurantDTO>>(restaurants);
        }

        public async Task<List<RestaurantDTO>> GetRestaurantsAsync()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            return _mapper.Map<List<RestaurantDTO>>(restaurants);
        }

        public async Task UpdateRestaurantAsync(RestaurantCreateEditDTO model)
        {
            var restaurant = _mapper.Map<Restaurant>(model);

            var categories = model.CategoriesIds
                .Select(item => _categoryRepository.GetByIdAsync(item).Result)
                .ToList();

            await _restaurantRepository.UpdateRestaurant(restaurant, categories);
        }
    }
}
