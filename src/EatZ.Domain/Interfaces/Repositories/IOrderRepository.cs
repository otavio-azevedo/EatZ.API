using EatZ.Domain.DTOs;
using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task InsertOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(long id);
        
        Task<IEnumerable<Order>> ListOrdersByUserIdAsync(string userId);

        Task<IEnumerable<Order>> ListOrdersByAdminIdAsync(string adminId);
        
        void RemoveOrder(Order order);
    }
}
