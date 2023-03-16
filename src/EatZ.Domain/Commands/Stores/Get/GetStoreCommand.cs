using EatZ.Domain.Entities;
using MediatR;

namespace EatZ.Domain.Commands.Stores.Get
{
    public class GetStoreCommand : IRequest<Store>
    {
        public GetStoreCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
