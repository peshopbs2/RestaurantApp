using RestaurantApp.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Restaurants = new HashSet<Restaurant>();
        }
        public string Name { get; set; }
        public virtual ICollection<Restaurant>? Restaurants { get; set; }
    }
}
