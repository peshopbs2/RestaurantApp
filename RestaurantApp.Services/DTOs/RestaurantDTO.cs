﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services.DTOs
{
    public class RestaurantDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PictureUrl { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public List<CategoryDTO> Categories { get; set; }
    }
}
