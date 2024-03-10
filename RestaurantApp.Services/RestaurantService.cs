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
        private readonly ICrudRepository<Restaurant> _repository;
        private readonly IMapper _mapper;
        public RestaurantService(ICrudRepository<Restaurant> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddRestaurantAsync(RestaurantDTO model)
        {
            var restaurant = _mapper.Map<Restaurant>(model);
            await _repository.AddAsync(restaurant);
        }

        public async Task DeleteRestaurantByIdAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<RestaurantDTO> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _repository
                .GetByIdAsync(id);
            return _mapper.Map<RestaurantDTO>(restaurant);
        }

        public async Task<List<RestaurantDTO>> GetRestaurantByNameAsync(string name)
        {
            var restaurants = await _repository.GetAsync(item => item.Name == name);
            return _mapper.Map<List<RestaurantDTO>>(restaurants);
        }

        public async Task<List<RestaurantDTO>> GetRestaurantsAsync()
        {
            var restaurants = await _repository.GetAllAsync();
            return _mapper.Map<List<RestaurantDTO>>(restaurants);
        }

        public async Task UpdateRestaurantAsync(RestaurantDTO model)
        {
            var restaurant = _mapper.Map<Restaurant>(model);
            await _repository.UpdateAsync(restaurant);
        }
    }
}
