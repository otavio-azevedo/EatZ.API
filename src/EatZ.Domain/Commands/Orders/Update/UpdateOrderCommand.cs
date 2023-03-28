using EatZ.Infra.CrossCutting.Enums;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Update
{
    public class UpdateOrderCommand : IRequest
    {
        public string OrderId { get; set; }

        public EOrderStatus Status { get; set; }
    }
}
