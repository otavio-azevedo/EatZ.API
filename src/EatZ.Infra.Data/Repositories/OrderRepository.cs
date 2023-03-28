using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EatZ.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EatzDbContext _context;

        public OrderRepository(EatzDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
    }
}
