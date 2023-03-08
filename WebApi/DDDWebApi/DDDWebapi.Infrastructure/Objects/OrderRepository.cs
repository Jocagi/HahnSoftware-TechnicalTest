using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDWebapi.Application.Common.Interfaces.Objects;
using DDDWebapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDWebapi.Infrastructure.Objects
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
