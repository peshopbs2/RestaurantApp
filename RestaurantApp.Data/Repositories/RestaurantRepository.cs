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

        public async Task UpdateRestaurant(Restaurant restaurant)
        {
            //TODO: remove categories
            await UpdateAsync(restaurant);
        }
    }
}
