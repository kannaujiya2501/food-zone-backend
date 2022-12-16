using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace food_zone.data
{
    public partial class Order
    {
        public Order()
        {
            Famousdish = new HashSet<Famousdish>();
        }

        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }

        public virtual ICollection<Famousdish> Famousdish { get; set; }
    }
}
