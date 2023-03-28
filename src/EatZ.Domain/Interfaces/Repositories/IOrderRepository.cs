using EatZ.Domain.Entities;

namespace EatZ.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task InsertOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(string id);
    }
}
