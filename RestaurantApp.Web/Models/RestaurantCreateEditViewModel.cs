using RestaurantApp.Services.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantApp.Web.Models
{
    public class RestaurantCreateEditViewModel : RestaurantCreateEditDTO
    {
        public IFormFile Picture { get; set; }
    }
}
