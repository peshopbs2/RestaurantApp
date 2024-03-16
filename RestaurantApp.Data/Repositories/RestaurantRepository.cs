using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Data;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Repositories
{
    public class RestaurantRepository
        : CrudRepository<Restaurant>, IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateRestaurant(Restaurant restaurant, List<Category> categories)
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
            _context.Restaurants.Attach(restaurant);

            if (!_context.Entry(restaurant).Collection(r => r.Categories).IsLoaded)
            {
                await _context.Entry(restaurant).Collection(r => r.Categories).LoadAsync();
            }
            restaurant.Categories = categories;

            await UpdateAsync(restaurant);
        }
    }
}
