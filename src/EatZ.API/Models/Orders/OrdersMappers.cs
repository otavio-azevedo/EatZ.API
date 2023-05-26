using EatZ.API.Models.Orders.Reponses;
using EatZ.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EatZ.API.Models.Orders
{
    public static class OrdersMappers
    {
        public static IEnumerable<ListOrdersByCurrentUserResponse> Map(IEnumerable<Order> orders)
        {
            if (orders.IsNullOrEmpty())
                return Enumerable.Empty<ListOrdersByCurrentUserResponse>();

            return orders.Select(s => new ListOrdersByCurrentUserResponse(
                s.Id,
                s.Store.Name,
                s.Status,
                s.CreationDate,
                s.PickUpDate,
                s.NetUnitPrice,
                s.Quantity,
                s.Total,
                s.Review?.Rating ?? 0));
        }
    }
}