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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
        }
    }
}
