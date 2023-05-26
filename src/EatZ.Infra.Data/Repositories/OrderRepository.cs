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

        public async Task<Order> GetOrderByIdAsync(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> ListOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                                 .Include(x => x.Store)
                                 .Include(x => x.Review)
                                 .Where(x => x.ClientUserId == userId)
                                 .OrderByDescending(x => x.CreationDate)
                                 .ToListAsync();

        }

        public async Task<IEnumerable<Order>> ListOrdersByAdminIdAsync(string adminId)
        {
            return await _context.Orders
                                 .Include(x => x.Store)
                                 .Include(x => x.Review)
                                 .Where(x => x.Store.AdminId == adminId)
                                 .OrderByDescending(x => x.CreationDate)
                                 .ToListAsync();
        }
    }
}
