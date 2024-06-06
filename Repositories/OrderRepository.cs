using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private Shop214662124Context _context;
        public OrderRepository(Shop214662124Context shop214662124Context)
        {
            _context = shop214662124Context;
        }


        public async Task<Order> CreateNewOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

    }
}
