using EatZ.Infra.CrossCutting.Enums;
using MediatR;

namespace EatZ.Domain.Commands.Orders.Create
{
    public class CreateOrderCommand : IRequest<string>
    {
        public string StoreId { get; set; }

        public string OfferId { get; set; }
    }
}
