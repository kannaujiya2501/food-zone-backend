using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace food_zone.data
{
    class OrderRepository
    {
        foodzoneContext context = new foodzoneContext();

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Order.ToList();
        }

        public void AddOrder(Order o)
        {
            context.Order.Add(o);
            context.SaveChanges();
        }

        public void UpdateOrder(Order o)
        {
            context.Entry<Order>(o).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            Order o = context.Order.Find(id);
            context.Order.Remove(o);
            context.SaveChanges();
        }
    }
}
