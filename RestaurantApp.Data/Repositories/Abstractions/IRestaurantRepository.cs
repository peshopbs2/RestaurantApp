using RestaurantApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Repositories.Abstractions
{
    public interface IRestaurantRepository : ICrudRepository<Restaurant>
    {
        public Task UpdateRestaurant(Restaurant restaurant, List<Category> categories);
    }
}
