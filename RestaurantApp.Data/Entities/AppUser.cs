using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Reviews = new HashSet<Review>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
