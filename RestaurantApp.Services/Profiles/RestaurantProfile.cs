using AutoMapper;
using RestaurantApp.Data.Entities;
using RestaurantApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Profiles
{
    internal class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>()
                .ReverseMap();
        }
    }
}
