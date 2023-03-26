using MediatR;

namespace EatZ.Domain.Commands.Offers.Delete
{
    public class DeleteOfferCommand : IRequest
    {
        public DeleteOfferCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
