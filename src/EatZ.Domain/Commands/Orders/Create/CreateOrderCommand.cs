using MediatR;

namespace EatZ.Domain.Commands.Orders.Create
{
    public class CreateOrderCommand : IRequest<long>
    {
        public string StoreId { get; set; }

        public string OfferId { get; set; }

        public int Quantity { get; set; }
    }
}