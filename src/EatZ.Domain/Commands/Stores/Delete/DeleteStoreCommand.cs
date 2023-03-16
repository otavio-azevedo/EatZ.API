using MediatR;

namespace EatZ.Domain.Commands.Stores.Delete
{
    public class DeleteStoreCommand : IRequest
    {
        public DeleteStoreCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
