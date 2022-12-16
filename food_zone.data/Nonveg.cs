using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace food_zone.data
{
    public partial class Nonveg
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
