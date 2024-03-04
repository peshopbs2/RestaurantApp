using RestaurantApp.Data.Entities.Abstractions;

namespace RestaurantApp.Data.Entities
{
    public class Restaurant : BaseEntity
    {
        public Restaurant()
        {
            Categories= new HashSet<Category>();
            Reviews = new HashSet<Review>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PictureUrl { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}