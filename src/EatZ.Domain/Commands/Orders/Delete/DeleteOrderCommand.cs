using MediatR;

namespace EatZ.Domain.Commands.Orders.Delete
{
    public class DeleteOrderCommand : IRequest
    {
        public DeleteOrderCommand(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }
    }
}
