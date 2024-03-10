using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.DTOs
{
    public class ReviewDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
