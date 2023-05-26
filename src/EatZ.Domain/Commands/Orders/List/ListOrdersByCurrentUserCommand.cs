using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Orders.List
{
    public class ListOrdersByCurrentUserCommand : IRequest<IEnumerable<Order>>
    {
    }
}
