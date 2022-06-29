﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokoFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
		[Required, StringLength(80)]
        public string? Name { get; set; }
        [Required, StringLength(255)]
        public string? Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
